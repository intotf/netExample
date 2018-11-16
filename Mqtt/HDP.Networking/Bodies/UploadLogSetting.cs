using HDP.Networking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 要求上传日志body
    /// </summary>
    public class UploadLogSetting
    {
        /// <summary>
        /// 上传的日志级别
        /// 可组合的值 
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
