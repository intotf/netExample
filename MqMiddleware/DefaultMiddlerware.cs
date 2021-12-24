using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    /// <summary>
    /// 默认中间件
    /// </summary>
    class DefaultMiddlerware : MiddlewareBase
    {

        /// <summary>
        /// 中间件业务执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override async Task Invoke(IContenxt context)
        {
            await Task.CompletedTask;
        }
    }
}
