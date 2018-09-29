using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable
{
    /// <summary>
    /// 订阅服务
    /// </summary>
    public class Servabler : IObservable<string>
    {
        /// <summary>
        /// 所有订阅者
        /// </summary>
        private List<IObserver<string>> Servablers = new List<IObserver<string>>();

        /// <summary>
        /// 当前客户端
        /// </summary>
        public IObserver<string> client;

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="observer"></param>
        /// <returns>返回 Subscriber 订阅者信息</returns>
        public IDisposable Subscribe(IObserver<string> client)
        {
            Servablers.Add(client);
            this.client = client;
            return new Subscriber(Servablers, client);
        }

        /// <summary>
        /// 通知订阅者
        /// </summary>
        public void Notify(string msg)
        {
            Servablers.ForEach((t) => t.OnNext(msg));
        }
    }

    /// <summary>
    /// 当前订阅者
    /// </summary>
    public class Subscriber : IDisposable
    {
        /// <summary>
        /// 所有订阅者
        /// </summary>
        private List<IObserver<string>> Servablers;

        /// <summary>
        /// 当前订阅者
        /// </summary>
        public IObserver<string> Client;

        /// <summary>
        /// 构造当前订阅者
        /// </summary>
        /// <param name="servablers"></param>
        /// <param name="client"></param>
        public Subscriber(List<IObserver<string>> servablers, IObserver<string> client)
        {
            this.Servablers = servablers;
            this.Client = client;
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        public void Dispose()
        {
            Servablers.Remove(Client);
        }
    }
}
