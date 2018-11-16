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
    /// 自定义智能设备 2
    /// </summary>
    public class CMCustomTwoSetting : CMCtrlRequest
    {
        /// <summary>
        /// 控制参数
        /// </summary>
        [EnumDefined]
        public CMCustomTwo CustomTwo { get; set; }
    }
}
