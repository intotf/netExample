using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    /// <summary>
    /// 中间键基类
    /// </summary>
    public abstract class MiddlewareBase : IMiddleware
    {
        private IMiddleware next;

        IMiddleware IMiddleware.Next
        {
            set
            {
                this.next = value;
            }
        }


        async Task IMiddleware.Invoke(IContenxt context)
        {
            await this.Invoke(context);
            Console.WriteLine("{0} : {1}", this.GetType().Name, context.Data.Title);
            await this.next.Invoke(context);

        }

        protected abstract Task Invoke(IContenxt context);


        public Config Config
        {
            get;
            set;
        }
    }
}
