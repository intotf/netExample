using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    /// <summary>
    /// 定义会话请求的上下文
    /// </summary>
    public interface IContenxt
    {
        /// <summary>
        /// 获取当前会话对象
        /// </summary>
        Dictionary<string, object> Dic { get; }

        /// <summary>
        /// 固定消息内容
        /// </summary>
        NotifData Data { get; }
    }
}
