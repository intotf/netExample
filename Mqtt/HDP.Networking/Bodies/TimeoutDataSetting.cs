using HDP.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 超时数据请求
    /// </summary>
    public class TimeoutDataSetting : ITimeoutRequest
    {
        /// <summary>
        /// 超时的秒数
        /// 如果设备在Timeout秒之后才收到数据则不处理
        /// </summary>
        [Range(1, 30)]
        public int Timeout { get; set; }

        /// <summary>
        /// 数据内容
        /// </summary>
        public string Data { get; set; }
    }
}
