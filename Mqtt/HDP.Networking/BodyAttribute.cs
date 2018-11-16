using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// 表示标记指令对应的Message的Body字段类型
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class BodyAttribute : Attribute
    {
        /// <summary>
        /// 获取发送时Body对应的类型
        /// </summary>
        public Type SendOrPostType { get; private set; }

        /// <summary>
        /// 获取或设置返回时Body对应的类型
        /// </summary>
        public Type ReturnType { get; set; }

        /// <summary>
        /// 获取或设置是否由客户端产生的请求
        /// </summary>
        public bool IsClientRequest { get; set; }

        /// <summary>
        /// 获取或设置请求的模式
        /// </summary>
        public Mode RequestMode { get; set; }

        /// <summary>
        /// 标记指令对应的Message的Body字段类型
        /// </summary>
        /// <param name="type">body类型</param>
        public BodyAttribute(Type type)
        {
            this.SendOrPostType = type;
            this.IsClientRequest = false;
            this.RequestMode = Mode.Send;
        }
    }
}
