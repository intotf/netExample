using Mqtt.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.NetWorking
{
    /// <summary>
    /// 表示mqtt分包数据集合
    /// 非线程安全类型
    /// </summary>
    public class MqttPackageCollection : IEnumerable<MqttPackage>
    {
        /// <summary>
        /// 数据包列表
        /// </summary>
        private readonly List<MqttPackage> list = new List<MqttPackage>();

        /// <summary>
        /// 同步锁
        /// </summary>
        public readonly object SyncRoot = new object();

        /// <summary>
        /// 获取数据包个数
        /// </summary>
        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        /// <summary>
        /// 获取数据包是否已完整
        /// </summary>
        public bool IsFin
        {
            get
            {
                var finItem = this.list.Find(item => item.Fin);
                if (finItem == null)
                {
                    return false;
                }
                return finItem.Index == this.list.Count - 1;
            }
        }

        /// <summary>
        /// 添加一个数据包
        /// </summary>
        /// <param name="item">数据包</param>
        /// <returns></returns>
        public bool Add(MqttPackage item)
        {
            if (list.Any(i => i.Index == item.Index))
            {
                return false;
            }
            this.list.Add(item);
            return true;
        }

        /// <summary>
        /// 清除所有数据包
        /// </summary>
        public void Clear()
        {
            this.list.Clear();
        }

        /// <summary>
        /// 将所有包合有效数据并为字节组
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            var index = 0;
            var size = this.list.Sum(item => item.Payload.Count);
            var buffer = new byte[size];

            foreach (var item in this.list.OrderBy(item => item.Index))
            {
                var length = item.Payload.Count;
                Array.Copy(item.Payload.Array, item.Payload.Offset, buffer, index, length);
                index = index + length;
            }
            return buffer;
        }

        /// <summary>
        /// 转换为Message对象
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public Message ToMessage()
        {
            if (this.IsFin == false)
            {
                throw new InvalidOperationException("IsFin为false，不能转换为Message");
            }

            var packet = this.list[0];
            var bytes = this.ToByteArray();
            var encoding = Utf8Encode.IsUtf8(bytes) ? Encoding.UTF8 : Encoding.GetEncoding("GBK");
            var bodyJson = encoding.GetString(bytes);
            var body = JsonSerializer.TryDeserialize<object>(bodyJson);

            return new Message
            {
                Api = packet.Api,
                Id = packet.Id,
                Mode = packet.Mode,
                Time = 0,
                Body = body
            };
        }

        /// <summary>
        /// 返回迭代器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<MqttPackage> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        /// <summary>
        /// 返回迭代器
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
