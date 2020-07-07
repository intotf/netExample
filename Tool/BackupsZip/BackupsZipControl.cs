using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text;
using Topshelf;

namespace BackupsZip
{
    /// <summary>
    /// 文件备份打包
    /// </summary>
    class BackupsZipControl : ServiceControl
    {
        /// <summary>
        /// 开始服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Start(HostControl hostControl)
        {
            Logger.Default.LogInformation($"{Assembly.GetExecutingAssembly().GetName().Name} 服务启动成功");
            var configJson = File.ReadAllText("config.json", Encoding.UTF8);
            var configs = JsonConvert.DeserializeObject<Config[]>(configJson);
            foreach (var item in configs)
            {
                new Backups(item);
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
            Logger.Default.LogInformation($"{Assembly.GetExecutingAssembly().GetName().Name} 服务已经停止");
            return true;
        }
    }
}
