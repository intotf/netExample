using Paho.MqttDotnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.NetWorking
{
    /// <summary>
    /// 表示mqtt分包数据
    /// 包头为固定12字节
    /// BigEndian
    /// </summary>
    public class MqttPackage
    {
        /// <summary>
        /// 0字节
        /// 值为0x2
        /// </summary>
        public const byte Mark = 0x2;

        /// <summary>
        /// 1-4字节
        /// Api指令
        /// </summary>
        public Api Api { get; set; }

        /// <summary>
        /// 5-5字节
        /// 消息模式
        /// </summary>
        public Mode Mode { get; set; }

        /// <summary>
        /// 6-9字节，
        /// 消息的唯一标识符
        /// mode为return时，id为发送的message的id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 10-10字节
        /// 表示包的索引
        /// </summary>
        public byte Index { get; set; }

        /// <summary>
        /// 11-11字节
        /// 表示是否为最后一个包
        /// </summary>
        public bool Fin { get; set; }

        /// <summary>
        /// 有效数据
        /// </summary>
        public ArraySegment<byte> Payload { get; set; }

        /// <summary>
        /// mqtt分包数据
        /// </summary>
        /// <param name="payload"></param>
        /// <exception cref="ArgumentException"></exception>
        public MqttPackage(byte[] payload)
        {
            if (payload.Length == 0 || payload[0] != MqttPackage.Mark)
            {
                throw new ArgumentException("mqttMessage不是MqttPackage");
            }

            this.Api = (Api)ByteConverter.ToInt32(payload, 1, Endians.Little);
            this.Mode = (Mode)payload[5];
            this.Id = ByteConverter.ToInt32(payload, 6, Endians.Little);
            this.Index = payload[10];
            this.Fin = payload[11] == 1;

            this.Payload = new ArraySegment<byte>(payload, 12, payload.Length - 12);
        }

        /// <summary>
        /// 获取唯一键
        /// </summary>
        /// <param name="uniqueId">设备标识</param>
        /// <returns></returns>
        public string GetUniqueKey(string uniqueId)
        {
            return string.Format("{0}_{1}_{2}", uniqueId, this.Id, (int)this.Api);
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var payload = Encoding.GetEncoding("GBK").GetString(this.Payload.Array, this.Payload.Offset, this.Payload.Count);
            return string.Format("Index: {0}  Fin: {1}  Payload", this.Index, this.Fin, payload);
        }

        /// <summary>
        /// 检测MqttMessage是否为MqttPackage
        /// </summary>
        /// <param name="mqttMessage"></param>
        /// <returns></returns>
        public static bool IsMqttPackage(MqttMessage mqttMessage)
        {
            var payload = mqttMessage.Payload;
            if (payload.Length == 0 || payload[0] != MqttPackage.Mark)
            {
                return false;
            }
            return true;
        }
    }
}
