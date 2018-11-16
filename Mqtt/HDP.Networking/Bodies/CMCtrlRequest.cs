using HDP.Networking.Enums;
using HDP.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 中控机下的设备控制请求
    /// </summary>
    public class CMCtrlRequest : ICMCtrlRequest, ITimeoutRequest
    {
        /// <summary>
        /// 超时的秒数
        /// 如果在Timeout秒之后才收到数据则不处理
        /// </summary>
        [Range(1, 30)]
        public int Timeout { get; set; }

        /// <summary>
        /// 中控机的设备id
        /// </summary>
        [Required]
        public string Id { get; set; }
    }
}
