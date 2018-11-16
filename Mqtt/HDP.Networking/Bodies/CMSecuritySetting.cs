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
    /// 安防设备通用实体
    /// </summary>
    public class CMSecuritySetting : CMCtrlRequest
    {
        /// <summary>
        /// 控制指令
        /// </summary>
        [EnumDefined]
        public CMSecurityState State { get; set; }
    }
}
