using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugsLib.plugs
{
    /// <summary>
    /// 插件抽象类
    /// </summary>
    public abstract class PlugBase : IPlug
    {
        /// <summary>
        /// 发送消息-子类可重写该方法
        /// </summary>
        public virtual void OnSend()
        {
            Console.WriteLine("正在处理.");
        }

        /// <summary>
        /// 需子类实现的抽象方法
        /// </summary>
        public abstract void Logs();
    }
}
