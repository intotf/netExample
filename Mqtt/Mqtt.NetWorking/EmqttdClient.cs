using Mqtt.Config;
using Paho.MqttDotnet;
using Mqtt.NetWorking.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mqtt.Common.Utility;
using Mqtt.Common.HttpContents;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Mqtt.NetWorking
{
    /// <summary>
    /// 表示emqttd的客户端
    /// </summary>
    [ConfigSection("Mqtt")]
    static class EmqttdClient
    {
        /// <summary>
        /// 当前消息的id
        /// </summary>
        private static int message_id = 0;

        /// <summary>
        /// 订阅账号互斥
        /// </summary>
        private static Mutex subMutex;

        /// <summary>
        /// 主题
        /// </summary>
        private static readonly string mqTopic = "pub/devices/+";

        /// <summary>
        /// 账号配置
        /// </summary>
        private static readonly MqttClientConfigSection config = ConfigSectionAttribute.GetConfigSection<MqttClientConfigSection>(typeof(EmqttdClient));


        /// <summary>
        /// mqtt客户端
        /// </summary>
        private static MqttClient _mqttClientInstance;

        /// <summary>
        /// 异步锁
        /// </summary>
        private static readonly AsyncRoot asyncRoot = new AsyncRoot();

        /// <summary>
        /// 任务表
        /// </summary>
        private static readonly TaskSetterTable<string> taskTable = new TaskSetterTable<string>();


        /// <summary>
        /// 初始化mqtt客户端
        /// </summary>
        /// <returns></returns>
        private async static Task InitMqttClientAsync()
        {
            using (await asyncRoot.LockAsync())
            {
                if (_mqttClientInstance != null)
                {
                    return;
                }

                var userName = EmqttdClient.GetSubAccout();
                var password = config.Subscribe.Password;

                await MqttAcl.AuthAclAsync(userName, password);
                await MqttAcl.AuthAclAsync(config.Publish.Account, config.Publish.Password);

                _mqttClientInstance = new MqttClient(config.Subscribe.Address, userName);
                _mqttClientInstance.OnMessageArrived += EmqttdClient.OnMqttClientReturn;
                _mqttClientInstance.OnConnectionLost += mqttClient_OnConnectionLost;
                var option = new ConnectOption
                {
                    Username = userName,
                    Password = password,
                };

                try
                {
                    Logger.Info("IIS_MQTT", "Connect " + option.ToDebugString());
                    await _mqttClientInstance.ConnectAsync(option);
                    Logger.Info("IIS_MQTT", "Connect OK ...");
                    await _mqttClientInstance.SubscribeAsync(mqTopic, MqttQoS.ExactlyOnce);
                }
                catch (Exception ex)
                {
                    Logger.Error("IIS_MQTT", ex.ToString());
                    Logger.Exception(ex);
                    throw ex;
                }
            }
        }


        /// <summary>
        /// 获取mqtt客户端实例
        /// </summary>
        private static async Task<MqttClient> GetMqttClientAsync()
        {
            await InitMqttClientAsync();
            return _mqttClientInstance;
        }

        /// <summary>
        /// 获取订阅账号
        /// </summary>
        /// <returns></returns>
        private static string GetSubAccout()
        {
            for (var i = 0; i < 20; i++)
            {
                var createdNew = false;
                var account = string.Format("{0}_{1}", config.Subscribe.Account, i + 1);

                var mutex = new Mutex(true, account, out createdNew);
                if (createdNew == true)
                {
                    EmqttdClient.subMutex = mutex;
                    return account;
                }
                else
                {
                    mutex.Dispose();
                }
            }
            return null;
        }

        /// <summary>
        /// 断线重连
        /// </summary>
        /// <param name="sender"></param>      
        private static async void mqttClient_OnConnectionLost(object sender)
        {
            Logger.Warn("IIS_MQTT", "ConnectionLost ...");
            var mqttClient = await GetMqttClientAsync();
            while (mqttClient.IsConnected == false)
            {
                try
                {
                    Logger.Info("IIS_MQTT", "ReConnecting ...");
                    await mqttClient.ReConnectAsync();
                    await mqttClient.SubscribeAsync(mqTopic, MqttQoS.ExactlyOnce);
                    Logger.Info("IIS_MQTT", "ReConnected OK ...");
                    break;
                }
                catch (Exception ex)
                {
                    Logger.Error("IIS_MQTT", ex.ToString());
                    Logger.Exception(ex);
                }
            }
        }

        /// <summary>
        /// 订阅处理回调
        /// pub/devices/*
        /// </summary>
        /// <param name="sender">事件发送者</param>
        /// <param name="topicName">主题</param>
        /// <param name="message">消息</param>
        private static void OnMqttClientReturn(object sender, string topicName, MqttMessage message)
        {
            var num = topicName.Split('/').LastOrDefault();
            if (MqttPackage.IsMqttPackage(message) == true)
            {
                ProcessPacketReturn(num, message);
            }
            else
            {
                ProcessJsonReturn(num, message);
            }
        }

        /// <summary>
        /// 处理mqtt分包回复
        /// </summary>
        /// <param name="num">机身号</param>
        /// <param name="mqttMessage">mqtt消息</param>
        private static void ProcessPacketReturn(string num, MqttMessage mqttMessage)
        {
            var packet = new MqttPackage(mqttMessage.Payload);
            if (packet.Mode != Mode.Return)
            {
                return;
            }

            var key = packet.GetUniqueKey(num);
            var taskSetter = taskTable.Get(key);

            if (taskSetter == null)
            {
                return;
            }

            lock (taskSetter.Packages.SyncRoot)
            {
                taskSetter.Packages.Add(packet);
                if (taskSetter.Packages.IsFin == false)
                {
                    return;
                }

                taskTable.Remove(key);
                var message = taskSetter.Packages.ToMessage();
                taskSetter.SetResult(message);
            }
        }

        /// <summary>
        /// 处理mqtt的json回复
        /// </summary>
        /// <param name="num">机身号</param>
        /// <param name="mqttMessage">mqtt消息</param>
        private static void ProcessJsonReturn(string num, MqttMessage mqttMessage)
        {
            var json = Encoding.UTF8.GetString(mqttMessage.Payload);
            var message = JsonSerializer.TryDeserialize<Message>(json);
            if (message == null || message.Mode != Mode.Return)
            {
                return;
            }

            var key = message.GetUniqueKey(num);
            var taskSetter = taskTable.Remove(key);

            if (taskSetter != null)
            {
                taskSetter.SetResult(message);
            }
        }

        /// <summary>
        /// 生成消息
        /// </summary>
        /// <param name="api">api</param>
        /// <param name="body">body</param>
        /// <param name="mode">mode</param>
        /// <returns></returns>
        private static Message GenerateMessage(Api api, object body, Mode mode)
        {
            Interlocked.CompareExchange(ref EmqttdClient.message_id, 0, int.MaxValue);
            var id = Interlocked.Increment(ref EmqttdClient.message_id);
            var time = (int)Math.Round(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            return new Message { Api = api, Mode = mode, Id = id, Time = time, Body = body };
        }

        /// <summary>
        /// 投递消息到远程端
        /// </summary>
        /// <param name="topic">主题</param>
        /// <param name="api">api</param>
        /// <param name="body">内容</param>
        /// <returns></returns>
        public static async Task PostAsync(Topic topic, Api api, object body)
        {
            var message = EmqttdClient.GenerateMessage(api, body, Mode.Post);
            await EmqttdClient.PublishAsync(topic, message);
        }

        /// <summary>
        /// 发送消息到远程端并等待返回
        /// </summary>
        /// <param name="topic">主题</param>
        /// <param name="api">api</param>
        /// <param name="body">内容</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message> SendAsync(SingleTopic topic, Api api, ITimeoutRequest body)
        {
            var message = EmqttdClient.GenerateMessage(api, body, Mode.Send);
            var key = message.GetUniqueKey(topic.UniqueId);
            var timeout = TimeSpan.FromSeconds(body.Timeout);
            var taskSetter = taskTable.Create<Message>(key, timeout);

            await EmqttdClient.PublishAsync(topic, message);
            return await taskSetter.GetTask();
        }

        /// <summary>
        /// 回复消息到远程端
        /// </summary>
        /// <param name="topic">主题</param>
        /// <param name="api">api</param>
        /// <param name="body">内容</param>
        /// <returns></returns>
        public static async Task ReturnAsync(SingleTopic topic, Api api, object body)
        {
            var message = GenerateMessage(api, body, Mode.Return);
            await EmqttdClient.PublishAsync(topic, message);
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="topic">主题</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        private static async Task PublishAsync(Topic topic, Message message)
        {
            // 发布前自动初始化mqtt客户端的订阅
            await InitMqttClientAsync();

            var messageJson = JsonSerializer.Serialize(message);
            var content = new XFormUrlEncodedContent(new
            {
                qos = 2,
                retain = 0,
                topic = topic.Value,
                message = messageJson
            });

            var basic = string.Format("{0}:{1}", config.Publish.Account, config.Publish.Password);
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(basic));

            var request = new HttpRequestMessage(HttpMethod.Post, config.Publish.Address) { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64);

            var response = await HttpApiClient.Default.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
