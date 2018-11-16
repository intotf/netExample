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
    /// 灯控总开关
    /// </summary>
    public class CMLampMasterSetting : CMCtrlRequest
    {
        /// <summary>
        /// 开关控制 
        /// </summary>
        [EnumDefined]
        public CMSwitch LampSwitch { get; set; }
    }
}
