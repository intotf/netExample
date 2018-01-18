using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    /// <summary>
    /// 防止外部多次实例外对象
    /// </summary>
    public class WorkLook : WorkBase
    {
        private WorkLook()
        {
            Console.WriteLine("我已经被创建过,重新创建无效 WorkLook");
        }

        /// <summary>
        /// 定义要创建的对象
        /// </summary>
        private static WorkLook _DemoClass = null;

        /// <summary>
        /// 对象锁,静态属性
        /// </summary>
        private static object _DemoLock = new object();

        /// <summary>
        /// 防止外部多次实例外对象
        /// 双 if  加 lock 为懒汉式
        /// </summary>
        /// <returns></returns>
        public static WorkLook CreateWorkLook()
        {
            if (_DemoClass == null)
            {
                lock (_DemoLock)  //锁定后，多线程进入后，只会创建一次
                {
                    Console.WriteLine("等待锁");
                    if (_DemoClass == null)
                    {
                        _DemoClass = new WorkLook();
                    }
                }
            }
            return _DemoClass;
        }

    }
}
