using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thirdlibrary
{
    class Program
    {
        public static PerformanceCounter pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("CPU使用率=" + CpuInfo.CpuUsage);
                //var sysInfo = new SystemInfo();
                ////Console.WriteLine("总共内存(M):" + (sysInfo.PhysicalMemory / 1024 / 1024));
                ////Console.WriteLine("可用内存(M):" + (sysInfo.MemoryAvailable / 1024 / 1024));
                //Console.WriteLine("CPU使用率={0}/{1} = {2}", sysInfo.CpuLoadAll, sysInfo.ProcessorCount, sysInfo.CpuLoad + "%");
                Thread.Sleep(1000);
            }
        }
    }
}
