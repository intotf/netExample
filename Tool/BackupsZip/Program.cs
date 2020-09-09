using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Topshelf;

namespace BackupsZip
{
    class Program
    {
        static void Main(string[] args)
        {
            var configPath = Path.Combine(System.Environment.CurrentDirectory, "config.json");
            Console.WriteLine("请将配置文件放到：" + configPath);
            //Console.ReadKey();

            var configJson = File.ReadAllText(configPath, Encoding.UTF8);
            var configs = JsonConvert.DeserializeObject<Config[]>(configJson);
            foreach (var item in configs)
            {
                new Backups(item);
            }

            //HostFactory.Run(c =>
            //{
            //    c.Service<BackupsZipControl>();
            //    c.RunAsLocalSystem();
            //    c.SetServiceName("BackupsZipServer");
            //    c.SetDisplayName("BackupsZipServer");
            //    c.SetDescription("BackupsZipServer");
            //});
        }
    }
}
