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
    /// 中央空调
    /// </summary>
    public class CMCentralAirSetting : CMCtrlRequest
    {
        /// <summary>
        /// 开关控制
        /// </summary>
        [EnumDefined]
        public CMCentralAir CentralAir { get; set; }
    }
}
