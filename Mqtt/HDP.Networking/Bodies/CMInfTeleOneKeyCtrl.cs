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
    /// 红外 [自定义遥控器1] 控制或学习
    /// </summary>
    public class CMInfTeleOneKeyCtrl : CMCtrlRequest
    {
        /// <summary>
        /// 控制按键
        /// </summary>
        [EnumDefined]
        public CMInfTeleOneKey Key { get; set; }
    }
}
