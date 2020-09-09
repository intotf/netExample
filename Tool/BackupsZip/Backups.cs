using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackupsZip
{
    /// <summary>
    /// 压缩备份文件
    /// </summary>
    public class Backups
    {
        /// <summary>
        /// 文件同步
        /// </summary>
        //private readonly Timer timer;

        /// <summary>
        /// 同步配置
        /// </summary>
        private Config Config;

        /// <summary>
        /// 构造目录同步
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public Backups(Config config)
        {
            this.Config = config;
            //this.timer = new Timer(TimerCallBack, null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan); ;
            if (config.SyncOne)
            {
                TimerCallBack(null);
            }
            //else
            //{
            //    SetNextChange(this.Config.ExecutionTime);
            //}
        }

        /// <summary>
        /// 设置下一次执行时间
        /// </summary>
        //private void SetNextChange(TimeSpan ts)
        //{
        //    var nextTime = DateTime.Now.Date.AddDays(1).Add(ts);
        //    Logger.Default.LogInformation($"{this.Config.SourcePath} 下次备份时间:{nextTime}");
        //    //执行完后,重新设置定时器下次执行时间.
        //    this.timer.Change(nextTime.Subtract(DateTime.Now), Timeout.InfiniteTimeSpan);
        //}

        /// <summary>
        /// 同步一次数据
        /// </summary>
        public void TimerCallBack(object state)
        {
            if (!Directory.Exists(this.Config.SourcePath))
            {
                Logger.Default.LogError($"{this.Config.SourcePath} 路径不存在.");
                return;
            }

            var sourceInfo = new DirectoryInfo(this.Config.SourcePath);
            var parentName = sourceInfo.Parent.FullName;

            //Zip 临时目录
            var zipTemp = Path.Combine(parentName, $"{sourceInfo.Name}_{DateTime.Now.ToString(this.Config.FileFormat)}");
            Directory.CreateDirectory(zipTemp);
            //复制目标文件内容至临时目录
            var searchOption = Config.IncludeSubdir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            Directory.EnumerateFiles(this.Config.SourcePath, Config.FilterType, searchOption).Select(item => new
            {
                sourceFile = item,
                targetFile = Path.Combine(zipTemp, Path.GetFullPath(item).Substring(Config.SourcePath.Length + 1))
            }).AsParallel().ForAll(item =>
            {
                this.CopyFile(item.sourceFile, item.targetFile);
            });

            //zip 临时文件
            var zipFile = $"{zipTemp}.zip";
            ZipLib.Zip(zipTemp, zipFile, Config.ZipLevel);
            Directory.Delete(zipTemp, true);
            var targetFile = Path.Combine(this.Config.TargetPath, Path.GetFileName(zipFile));
            CopyFile(zipFile, targetFile);
            File.Delete(zipFile);
            Logger.Default.LogInformation($"{this.Config.SourcePath} 成功压缩备份到 ：{targetFile}");
            //SetNextChange(this.Config.ExecutionTime);
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        public void CopyFile(string sourceFile, string targetFile)
        {
            //目录目录不存在则复制
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(targetFile));
                File.Copy(sourceFile, targetFile, true);
                //Logger.Default.LogInformation(string.Format("Copy:{0} To {1}", sourceFile, targetFile));
            }
            catch (Exception ex)
            {
                Logger.Default.LogError(string.Format("Copy:{0} To {1} \n\r{2}", sourceFile, targetFile, ex.Message));
            }
        }
    }
}
