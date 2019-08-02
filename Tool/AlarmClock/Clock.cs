using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmClock
{
    /// <summary>
    /// 闹钟
    /// </summary>
    public class Clock
    {
        /// <summary>
        /// 定时器
        /// </summary>
        private System.Threading.Timer timer;

        /// <summary>
        /// 响铃时间
        /// </summary>
        public DateTime RingTime { get; set; }

        /// <summary>
        /// 时间Id
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 备注消息
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 回调动作
        /// </summary>
        public Action<string> CallBackAction { get; set; }


        /// <summary>
        /// 是否循环执行
        /// </summary>
        public bool IsCycle { get; set; }

        /// <summary>
        /// 间隔秒
        /// </summary>
        public long IntervalSpan { get; set; }

        public Clock() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="action"></param>
        /// <param name="isCycle"></param>
        /// <param name="note"></param>
        public Clock(TimeSpan timeSpan, Action<string> action, bool isCycle = false, string note = "无")
            : this(DateTime.Now.Add(timeSpan), action, isCycle, note)
        {

        }

        /// <summary>
        /// 响铃时间
        /// </summary>
        /// <param name="ringTime"></param>
        public Clock(DateTime ringTime, Action<string> action, bool isCycle = false, string note = "无")
        {
            this.Note = note;
            this.CallBackAction = action;
            this.RingTime = ringTime;
            this.IsCycle = isCycle;
            var timeSpan = ringTime.Subtract(DateTime.Now);
            this.IntervalSpan = (long)timeSpan.TotalSeconds;
            if (this.IntervalSpan > 0)
            {
                this.timer = new System.Threading.Timer(TimerCallBack, null, timeSpan, Timeout.InfiniteTimeSpan);
            }
        }

        public void TimerCallBack(object state)
        {
            this.timer.Dispose();
            this.CallBackAction.Invoke(this.Id);
            Console.WriteLine(DateTime.Now);
        }
    }
}
