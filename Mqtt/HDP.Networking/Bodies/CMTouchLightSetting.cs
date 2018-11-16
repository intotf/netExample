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
    /// 触摸灯控
    /// </summary>
    public class CMTouchLightSetting : CMCtrlRequest
    {
        /// <summary>
        /// 开关控制 
        /// </summary>
        [EnumDefined]
        public CMTouchLight LightSwitch { get; set; }
    }
}
