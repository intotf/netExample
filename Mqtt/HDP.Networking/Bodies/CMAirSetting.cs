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
    /// 智能空调
    /// </summary>
    public class CMAirSetting : CMCtrlRequest
    {
        /// <summary>
        /// 控制参数
        /// </summary>
        [EnumDefined]
        public CMAir AirEnums { get; set; }
    }
}
