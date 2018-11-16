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
    /// 空调开关
    /// </summary>
    public class CMAirSwitchSetting : CMCtrlRequest
    {
        /// <summary>
        /// 控制指令
        /// </summary>
        [EnumDefined]
        public CMAirSwitch AirSwitch { get; set; }
    }
}
