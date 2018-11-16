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
    /// 窗帘
    /// </summary>
    public class CMCurtainSetting : CMCtrlRequest
    {
        /// <summary>
        /// 打开程度
        /// </summary>
        [EnumDefined]
        public CMSchedule Schedule { get; set; }
    }
}
