using HDP.Networking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 红外电视按键学习状态
    /// </summary>
    public class CMInfTvKeyState
    {
        /// <summary>
        /// 键
        /// </summary>
        public CMInfTvKey Key { get; set; }

        /// <summary>
        /// 是否已学习
        /// </summary>
        public bool IsLearned { get; set; }

        /// <summary>
        /// 键的显示名称
        /// </summary>
        public string Name { get; set; }
    }
}
