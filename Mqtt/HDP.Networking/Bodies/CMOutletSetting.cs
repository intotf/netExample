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
    /// 插座
    /// </summary>
    public class CMOutletSetting : CMCtrlRequest
    {
        /// <summary>
        /// 开关指令 
        /// </summary>
        [EnumDefined]
        public CMSwitch OutletSwitch { get; set; }
    }
}
