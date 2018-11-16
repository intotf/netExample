using Mqtt.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.NetWorking
{
    /// <summary>
    /// 表示MQTT的消息
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Api指令
        /// </summary>
        public Api Api { get; set; }

        /// <summary>
        /// 发送或回复时的unix时间戳(s)
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// 消息模式
        /// </summary>
        public Mode Mode { get; set; }

        /// <summary>
        /// 消息的唯一标识符
        /// mode为return时，id为发送的message的id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 发送或回复的内容体
        /// </summary>
        public object Body { get; set; }


        /// <summary>
        /// 转换Body为强类型
        /// </summary>
        /// <typeparam name="TBody">Body类型</typeparam>
        /// <returns></returns>
        public Message<TBody> Cast<TBody>()
        {
            var message = new Message<TBody>
            {
                Api = this.Api,
                Id = this.Id,
                Mode = this.Mode,
                Time = this.Time,
                Body = JsonSerializer.ConvertTo<TBody>(this.Body)
            };
            return message;
        }

        /// <summary>
        /// 获取唯一键
        /// </summary>
        /// <param name="uniqueId">设备标识</param>
        /// <returns></returns>
        public string GetUniqueKey(string uniqueId)
        {
            var key = string.Format("{0}_{1}_{2}", uniqueId, this.Id, (int)this.Api);
            return key;
        }

        /// <summary>
        /// 从 json转换得到
        /// </summary>
        /// <param name="json">json</param>
        /// <returns></returns>
        public static Message Parse(string json)
        {
            return JsonSerializer.TryDeserialize<Message>(json);
        }
    }


    /// <summary>
    /// 表示MQTT的消息
    /// </summary>
    /// <typeparam name="TBody"></typeparam>
    public class Message<TBody>
    {
        /// <summary>
        /// Api
        /// </summary>
        public Api Api { get; set; }

        /// <summary>
        /// 时间unix时间戳(s)
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// 模式
        /// </summary>
        public Mode Mode { get; set; }

        /// <summary>
        /// 消息的唯一标识符
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 内容体
        /// </summary>
        public TBody Body { get; set; }
    }
}
