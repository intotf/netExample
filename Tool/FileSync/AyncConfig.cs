using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    /// <summary>
    /// 同步数据配置
    /// </summary>
    public class AyncConfig
    {
        /// <summary>
        /// 来源目录/监控目录
        /// </summary>
        public string SourcePath { get; set; }

        /// <summary>
        /// 同步目录
        /// </summary>
        public string TargetPath { get; set; }

        /// <summary>
        /// 马上同步一次
        /// </summary>
        public bool SyncOne { get; set; } = false;

        /// <summary>
        /// 监控的文件类型
        /// </summary>
        public string FilterType { get; set; } = "*.*";

        /// <summary>
        /// 是否监听子目录
        /// </summary>
        public bool IncludeSubdir { get; set; } = true;

        /// <summary>
        /// 同步延迟秒数,默认 3秒
        /// </summary>
        public int DelaySeconds { get; set; } = 3;

        /// <summary>
        /// 是否同步删除
        /// </summary>
        public bool IsAyncDelete { get; set; } = false;
    }
}
