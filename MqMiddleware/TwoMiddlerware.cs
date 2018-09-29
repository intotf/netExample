using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    class TwoMiddlerware : MiddlewareBase
    {
        protected override async Task Invoke(IContenxt context)
        {
            var c = this.Config as YiYingCong;
            context.Data.Title += "||";
            await Task.CompletedTask;
        }
    }
}
