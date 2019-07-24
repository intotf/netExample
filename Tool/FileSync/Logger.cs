using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    /// <summary>
    /// 表示日志
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// 获取日志工厂
        /// </summary>
        public static readonly ILoggerFactory Factory;

        /// <summary>
        /// 获取默认实例
        /// </summary>
        public static readonly ILogger Default;

        /// <summary>
        /// 日志初始化
        /// </summary>
        static Logger()
        {
            Factory = new LoggerFactory().AddConsole().AddDebugger();
            Default = Factory.CreateLogger("FileSyncLogs");
        }
    }
}
