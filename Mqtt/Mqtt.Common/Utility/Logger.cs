using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.Common.Utility
{
    public static class Logger
    {
        /// <summary>
        /// 日志
        /// </summary>
        static Logger()
        {
            //var section = ConfigSectionAttribute.GetConfigSection<ExceptionlessSection>(typeof(Logger));
            //var config = ExceptionlessClient.Default.Configuration;
            //config.ApiKey = section.ApiKey;
            //if (string.IsNullOrEmpty(section.ServerUrl) == false)
            //{
            //    config.ServerUrl = section.ServerUrl;
            //}
            //ExceptionlessClient.Default.Startup();
        }

        /// <summary>
        /// 显示地初始化
        /// </summary>
        public static void Init()
        {
        }

        /// <summary>
        /// 提交异常
        /// </summary>
        /// <param name="ex">异常</param>
        public static void Exception(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        /// <summary>
        /// 提交Debug日志
        /// </summary>
        /// <param name="log">日志</param>
        public static void Debug(string source, string log)
        {
            Console.WriteLine("{0}：{1}", source, log);
        }

        /// <summary>
        /// 提交Info日志
        /// </summary>
        /// <param name="log">日志</param>
        public static void Info(string source, string log)
        {
            Console.WriteLine("{0}：{1}", source, log);
        }

        /// <summary>
        /// 提交Error日志
        /// </summary>
        /// <param name="log">日志</param>
        public static void Warn(string source, string log)
        {
            Console.WriteLine("{0}：{1}", source, log);
        }

        /// <summary>
        /// 提交Error日志
        /// </summary>
        /// <param name="log">日志</param>
        public static void Error(string source, string log)
        {
            Console.WriteLine("{0}：{1}", source, log);
        }
    }
}
