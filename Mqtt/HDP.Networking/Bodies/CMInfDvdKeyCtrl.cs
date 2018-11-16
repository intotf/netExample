using HDP.Networking.Enums;
using HDP.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 红外背景音乐控制或学习
    /// </summary>
    public class CMInfDvdKeyCtrl : CMCtrlRequest
    {
        /// <summary>
        /// 控制按键
        /// </summary>
        [EnumDefined]
        public CMInfDvdKey Key { get; set; }
    }
}
