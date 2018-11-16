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
    /// 灯控开关
    /// </summary>
    public class CMLightControlSetting : CMCtrlRequest
    {
        /// <summary>
        /// 开关指令
        /// </summary>
        [EnumDefined]
        public CMSwitch LightSwitch { get; set; }
    }
}
