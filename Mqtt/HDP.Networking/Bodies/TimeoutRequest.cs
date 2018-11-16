using HDP.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 表示超时的Body
    /// </summary>
    public sealed class TimeoutRequest : ITimeoutRequest
    {
        /// <summary>
        /// 超时的秒数
        /// 如果在Timeout秒之后才收到数据则不处理
        /// </summary>
        [Range(1, 30)]
        public int Timeout { get; set; }

        /// <summary>
        /// 获取默认的超时body
        /// 5s
        /// </summary>
        public static readonly TimeoutRequest Default = new TimeoutRequest { Timeout = 5 };
    }
}
