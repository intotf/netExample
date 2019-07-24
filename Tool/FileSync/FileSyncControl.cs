using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Microsoft.Extensions.Logging;

namespace FileSync
{
    /// <summary>
    /// 文件同步服务
    /// </summary>
    public class FileSyncControl : ServiceControl
    {
        /// <summary>
        /// 开始服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Start(HostControl hostControl)
        {
            Logger.Default.LogInformation("FileSync 服务启动成功");
            var configJson = File.ReadAllText("config.json", Encoding.UTF8);
            var listAsync = JsonConvert.DeserializeObject<AyncConfig[]>(configJson);
            foreach (var item in listAsync)
            {
                new DirectoryAync(item);
            }
            return true;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Stop(HostControl hostControl)
        {
            Logger.Default.LogInformation("FileSync 服务已经停止");
            return true;
        }

    }
}
