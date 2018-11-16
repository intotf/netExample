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
    /// DVD 控制器
    /// </summary>
    public class CMDvdSetting : CMCtrlRequest
    {
        /// <summary>
        /// 控制参数
        /// </summary>
        [EnumDefined]
        public CMDvd DvdEnums { get; set; }
    }
}
