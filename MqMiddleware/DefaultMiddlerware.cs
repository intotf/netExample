using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    class DefaultMiddlerware : MiddlewareBase
    {

        protected override async Task Invoke(IContenxt context)
        {
            await Task.CompletedTask;
        }
    }
}
