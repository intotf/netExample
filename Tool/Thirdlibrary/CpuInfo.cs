using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirdlibrary
{
    /// <summary>
    /// 当前电脑CPU信息
    /// </summary>
    public static class CpuInfo
    {
        /// <summary>
        /// Windows 性能数器组件
        /// </summary>
        private static PerformanceCounter performanceCounter = new PerformanceCounter();

        /// <summary>
        /// Cpu 数量
        /// </summary>
        private static int CpuCount = Environment.ProcessorCount;

        /// <summary>
        /// Cpu 使用率
        /// </summary>
        public static float CpuUsage
        {
            get
            {
                return performanceCounter.NextValue();
            }
        }

        /// <summary>
        /// 设置性能组件
        /// </summary>
        static CpuInfo()
        {
            performanceCounter.CategoryName = "Processor Information";
            performanceCounter.CounterName = "% Processor Time";
            performanceCounter.InstanceName = "_Total";
            performanceCounter.MachineName = ".";
            performanceCounter.ReadOnly = true;
            performanceCounter.NextValue();
        }
    }
}
