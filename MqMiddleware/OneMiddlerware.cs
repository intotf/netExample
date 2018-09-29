using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    class OneMiddlerware : MiddlewareBase
    {
        protected override async Task Invoke(IContenxt context)
        {
            var c = this.Config as YiYingCong;
        
            await Task.CompletedTask;
        }
    }
}
