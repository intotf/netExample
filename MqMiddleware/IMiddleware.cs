using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    /// <summary>
    /// 定义协议中间件的行为
    /// </summary>
    public interface IMiddleware
    {
        /// <summary>
        /// 下一个中间件
        /// </summary>
        IMiddleware Next { set; }

        /// <summary>
        /// 中间间配置
        /// </summary>
        Config Config { get; set; }

        /// <summary>
        /// 当IListener收到会话的请求后
        /// 提供IContenxt并执行此方法
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        Task Invoke(IContenxt context);
    }
}
