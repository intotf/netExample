using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Enums
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 信息
        /// </summary>
        [Display(Name = "信息")]
        Info = 1,

        /// <summary>
        /// 警告
        /// </summary>
        [Display(Name = "警告")]
        Warn = 2,

        /// <summary>
        /// 错误
        /// </summary>
        [Display(Name = "错误")]
        Error = 4
    }
}
