using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupsZip
{
    public class Config
    {
        /// <summary>
        /// 来源目录/监控目录
        /// </summary>
        public string SourcePath { get; set; }

        /// <summary>
        /// 打包后目录
        /// 可为相对路径或绝对路径
        /// </summary>
        public string TargetPath { get; set; }

        /// <summary>
        /// 马上执行一次
        /// </summary>
        public bool SyncOne { get; set; } = true;

        /// <summary>
        /// 文件格式 yyyyMMdd
        /// </summary>
        public string FileFormat { get; set; } = "yyyyMMdd";

        /// <summary>
        /// 是否包含子目录
        /// </summary>
        public bool IncludeSubdir { get; set; } = true;

        /// <summary>
        /// 执行时间
        /// </summary>
        public TimeSpan ExecutionTime { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FilterType { get; set; } = "*.*";

        /// <summary>
        /// 压缩等级 0 -9
        /// </summary>
        public int ZipLevel { get; set; } = 6;
    }
}
