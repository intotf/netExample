using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileSync
{
    /// <summary>
    /// 目录同步
    /// </summary>
    public class DirectoryAync
    {
        /// <summary>
        /// 文件同步
        /// </summary>
        private FileTimer fileTimer;

        /// <summary>
        /// 同步配置
        /// </summary>
        private AyncConfig Config;

        /// <summary>
        /// 构造目录同步
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public DirectoryAync(AyncConfig config)
        {
            this.Config = config;
            if (this.Config.DelaySeconds < 1)
            {
                this.Config.DelaySeconds = 1;
            }
            this.fileTimer = new FileTimer(TimeSpan.FromSeconds(this.Config.DelaySeconds));
            if (config.SyncOne)
            {
                Task.Factory.StartNew(OneAsyn);
            }
            ListenStart();
        }

        /// <summary>
        /// 同步一次数据
        /// </summary>
        private void OneAsyn()
        {
            var searchOption = Config.IncludeSubdir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            //var leftFiles = Directory.EnumerateFiles(Config.SourcePath, Config.FilterType, searchOption).Select(item => Path.GetFullPath(item).Substring(Config.SourcePath.Length)).ToArray();
            //var rightFiles = Directory.EnumerateFiles(Config.TargetPath, Config.FilterType, searchOption).Select(item => Path.GetFullPath(item).Substring(Config.TargetPath.Length)).ToArray();
            //var LRFiles = leftFiles.Except(rightFiles).Select(item => Path.Combine(Config.SourcePath, item));
            //Logger.Default.LogInformation(string.Format("共有 {0} 文件需要从监控文件夹复制到目标.", LRFiles.Count()));
            //this.CopyToTarget(LRFiles);
            Directory.EnumerateFiles(Config.SourcePath, Config.FilterType, searchOption).AsParallel().ForAll(item =>
            {
                CopyToTarget(item);
            });
        }

        /// <summary>
        /// 开始监听来源目录
        /// </summary>
        public void ListenStart()
        {
            var watcher = new FileSystemWatcher();
            watcher.BeginInit();
            watcher.Filter = Config.FilterType;
            watcher.IncludeSubdirectories = Config.IncludeSubdir;
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            //设置监听的路径
            watcher.Path = Config.SourcePath;
            watcher.Changed += Watcher_Changed;
            watcher.EndInit();
        }

        /// <summary>
        /// 目录变化监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                fileTimer.Invoke(e.FullPath, () => CopyToTarget(e.FullPath));
            }
        }

        #region 复制文件
        /// <summary>
        /// 复制文件
        /// </summary>
        public void CopyFile(string sourceFile, string targetFile)
        {
            //目录目录不存在则复制
            if (File.Exists(targetFile) == false && File.Exists(sourceFile) == true)
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(targetFile));
                    File.Copy(sourceFile, targetFile, true);
                    Logger.Default.LogInformation(string.Format("Copy:{0} To {1}", sourceFile, targetFile));

                    #region 同步到七牛空间
                    //var mac = new Mac("njrN4I3Fp-UtpkYL4pl2Ou18WLEUcEo22H_m2E8L", "v9DtR-o1PSNS7xD45Ou9BAmVvzcI1UpcEZ-d3n8C");
                    //PutPolicy putPolicy = new PutPolicy();
                    //putPolicy.Scope = "intotf";
                    //putPolicy.SaveKey = "FileSync\a\b";

                    //// 生成上传token
                    //string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
                    //var config = new Config();
                    //config.Zone = Zone.ZONE_CN_South;
                    //// 表单上传
                    //FormUploader target = new FormUploader(config);
                    //var result = target.UploadFile(sourceFile, Path.GetFileName(sourceFile), token, null);
                    //Console.WriteLine(result.ToString());
                    #endregion
                }
                catch (Exception ex)
                {
                    Logger.Default.LogError(string.Format("Copy:{0} To {1} \n\r{2}", sourceFile, targetFile, ex.Message));
                }
            }
        }



        /// <summary>
        /// 从源文件目录复制到目标文件
        /// </summary>
        /// <param name="sourceFile"></param>
        public void CopyToTarget(string sourceFile)
        {
            var targetFile = Path.Combine(Config.TargetPath, Path.GetFullPath(sourceFile).Substring(Config.SourcePath.Length));
            this.CopyFile(sourceFile, targetFile);
        }

        /// <summary>
        /// 从源文件目录复制到目标文件
        /// </summary>
        /// <param name="sourceFile"></param>
        public void CopyToTarget(IEnumerable<string> sourceFiles)
        {
            sourceFiles.Select(item => new
            {
                sourceFile = item,
                targetFile = Path.Combine(Config.TargetPath, Path.GetFullPath(item).Substring(Config.SourcePath.Length))
            }).AsParallel().ForAll(item =>
            {
                this.CopyFile(item.sourceFile, item.targetFile);
            });
        }
        #endregion
    }
}