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
    /// 百朗新风系统
    /// </summary>
    public class CMBLFreshAirSetting: CMCtrlRequest
    {
        /// <summary>
        /// 开关控制
        /// </summary>
        [EnumDefined]
        public CMBLFreshAir BLFreshAir { get; set; }
    }
}
