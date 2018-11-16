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
    /// 新风系统设备
    /// </summary>
    public class CMFreshAirSetting : CMCtrlRequest
    {
        /// <summary>
        /// 控制参数
        /// </summary>
        [EnumDefined]
        public CMFreshAir FreshAir { get; set; }
    }
}
