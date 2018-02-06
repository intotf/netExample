using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ExampleLib
{
    /// <summary>
    /// System.Timers 定时器
    /// System.Threading.Timer 是基于线程
    /// </summary>
    public class SystemTimer
    {
        private static Timer timer = new Timer();

        /// <summary>
        /// System.Timers.Timer 定时执行
        /// </summary>
        public static void Demo()
        {
            timer.Interval = 3000;
            timer.Enabled = true;       //是否启用
            timer.AutoReset = true;     //是否启用事件
            timer.Elapsed += timer_Elapsed;
        }

        /// <summary>
        /// 定时执行的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("System.Timers.Timer 定时执行效果");
        }
    }
}
