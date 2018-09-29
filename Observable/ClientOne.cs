using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable
{
    /// <summary>
    /// 客户端2
    /// </summary>
    public class ClientOne : IObserver<string>
    {
        /// <summary>
        /// 当消息处理完后
        /// </summary>
        public void OnCompleted()
        {
            Console.WriteLine("消息处理完成");
        }

        /// <summary>
        /// 当有异常时
        /// </summary>
        /// <param name="error"></param>
        public void OnError(Exception error)
        {
            Console.WriteLine("异常:{0}", error.Message);
        }

        /// <summary>
        /// 接收消息处理
        /// </summary>
        /// <param name="value"></param>
        public void OnNext(string value)
        {
            Console.WriteLine(this.GetType().Name + ":" + value);
        }
    }
}
