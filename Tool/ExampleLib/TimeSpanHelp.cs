using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleLib
{
    /// <summary>
    /// TimeSpan 及 Tasks.Timer  学习
    /// 1.Timer 和 CancellationTokenSource 定时间触发
    /// 2.时间之间转换
    /// </summary>
    public class TimeSpanHelp
    {
        private Timer timer;

        private TimeSpanHelp()
        {

        }

        /// <summary>
        /// 构建对象
        /// </summary>
        /// <returns></returns>
        public static TimeSpanHelp Instance()
        {
            return new TimeSpanHelp();
        }

        /// <summary>
        /// CancellationTokenSource 方式定时执行任务
        /// </summary>
        /// <param name="interval"></param>
        public void CancellationDeme(TimeSpan interval)
        {
            CancellationTokenSource sourct = new CancellationTokenSource(interval);
            Console.WriteLine("CancellationTokenSource 定时取消任务计时开始.{0} 秒取消任务", interval.Seconds);
            sourct.Token.Register(() =>
            {
                Console.WriteLine("定时取消任务");
                CancellationDeme(interval);
            });
        }
        /// <summary>
        /// Timer 定时处理任务
        /// </summary>
        /// <param name="interval">间隔时间,单位</param>
        public void TimerDemo(TimeSpan interval)
        {
            if (this.timer == null)
            {
                var i = 0;
                TimeSpan dueTime = DateTime.Now.Add(interval).Subtract(DateTime.Now);
                this.timer = new Timer((state) =>
                {
                    i++;
                    Console.WriteLine("定时执行任务 {0} 次,间隔时间：{1}ms,下次执行时间：{2}", i, interval.TotalMilliseconds, DateTime.Now.Add(interval));
                }, null, dueTime, interval);
            }
        }

        /// <summary>
        /// 获取两个时间的时间差
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public TimeSpan GetSubtract(DateTime StartTime, DateTime EndTime)
        {
            var ts = new TimeSpan(StartTime.Ticks);
            return StartTime.Subtract(EndTime);
        }
    }
}
