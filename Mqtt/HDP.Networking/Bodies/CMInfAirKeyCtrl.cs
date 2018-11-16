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
    /// 红外空调控制或学习
    /// </summary>
    public class CMInfAirKeyCtrl : CMCtrlRequest
    {
        /// <summary>
        /// 控制按键
        /// </summary>
        [EnumDefined]
        public CMInfAirKey Key { get; set; }
    }
}
