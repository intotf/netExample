using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    class MiddlewareManager
    {
        /// <summary>
        /// 所有中间件
        /// </summary>
        private readonly LinkedList<IMiddleware> middlewares = new LinkedList<IMiddleware>();

        /// <summary>
        /// 当前所有中间件
        /// </summary>
        private readonly List<IMiddleware> ms = new List<IMiddleware>();


        public MiddlewareManager()
        {
            this.ms.Add(new DefaultMiddlerware());
        }


        /// <summary>
        /// 使用协议中间件
        /// </summary>
        /// <typeparam name="TMiddleware">中间件类型</typeparam>
        /// <returns></returns>
        public TMiddleware Use<TMiddleware>( Config config) where TMiddleware : IMiddleware
        {
            var middleware = Activator.CreateInstance<TMiddleware>();
            middleware.Config = config;
            this.Use(middleware);
            return middleware;
        }


        public void Use(IMiddleware middleware)
        {
            if (middleware == null)
            {
                throw new ArgumentNullException();
            }

            ms.Add(middleware);
            ms.Aggregate((prev, next) =>
            {
                prev.Next = next;
                return next;
            }).Next = default(IMiddleware);
        }

        /// <summary>
        /// 清除所有协议中间件
        /// </summary>
        public void Clear()
        {
            this.ms.Clear();
        }

        /// <summary>
        /// 触发执行中间件
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public Task RaiseInvoke(IContenxt context)
        {

            //ms.ForEach(async (a) =>
            //{
            //    if(a.Next)
            //    await a.Invoke(context);
            //});
            return ms.First().Invoke(context);
            //return this.middlewares.First.Value.Invoke(context);
        }
    }
}
