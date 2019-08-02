using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    /// <summary>
    /// dategirdView 数据模型
    /// </summary>
    public class GridMode
    {
        /// <summary>
        /// 响铃时间
        /// </summary>
        public DateTime RingTime { get; set; }

        /// <summary>
        /// 时间Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 备注消息
        /// </summary>
        public string Note { get; set; }
    }
}
