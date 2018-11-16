using Paho.MqttDotnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttConsole
{
    public class MqttClient
    {
        /// <summary>
        /// 客户端id
        /// </summary>
        string clientId { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        string topic = "";

        /// <summary>
        /// mqtt客户端
        /// </summary>
        MqttClient mqttClient { get; set; }

        /// <summary>
        /// 当收到消息时
        /// </summary>
        public event Action<MqttMessage> OnMessage;

        /// <summary>
        /// 实例化Mqtt连接
        /// </summary>
        /// <param name="serverUri">Mqtt服务Uri</param>
        /// <param name="clientId">客户端id</param>
        /// <returns></returns>
        public static MqttClient Instance(string serverUri, string clientId)
        {
            return new Paho.MqttDotnet.MqttClient(serverUri, clientId);
        }

        /// <summary>
        /// 订阅主题
        /// </summary>
        public async void Subscribe(string topic)
        {
            this.topic = topic;
            await this.mqttClient.SubscribeAsync(topic, MqttQoS.ExactlyOnce);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg">发送消息</param>
        public void SendMessage(string msg, MqttQoS qos = MqttQoS.AtLeastOnce)
        {
            var mqttMsg = new MqttMessage
            {
                Retain = false,
                Dup = false,
                Payload = Encoding.UTF8.GetBytes(msg),
                QoS = qos
            };
            mqttClient.SendMessageAsync(this.topic, mqttMsg);
        }

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="serverUri">Mqtt服务Uri</param>
        /// <param name="clientId">客户端id</param>
        private MqttClient(string serverUri, string clientId)
        {
            this.clientId = clientId;
            mqttClient = new MqttClient(serverUri, clientId);
            mqttClient.ConnectAsync(new ConnectOption
            {

            });
            //TryConnectAsync();
            mqttClient.OnConnectionLost += mqttClient_OnConnectionLost;
            mqttClient.OnMessageArrived += mqttClient_OnMessageArrived;
        }

        /// <summary>
        /// 收到消息时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        void mqttClient_OnMessageArrived(object sender, string topic, MqttMessage message)
        {
            if (this.OnMessage != null)
            {
                OnMessage.Invoke(message);
            }
        }

        /// <summary>
        /// 断开连接时 
        /// </summary>
        /// <param name="sender"></param>
        void mqttClient_OnConnectionLost(object sender)
        {
            Console.WriteLine("连接已经断开,正在尝试重新连接");
            TryConnectAsync();
        }

        /// <summary>
        /// 重试连接服务
        /// </summary>
        async void TryConnectAsync()
        {
            while (mqttClient.IsConnected == false)
            {
                await mqttClient.ConnectAsync(new ConnectOption { CleanSession = false });
            }
        }
    }
}
