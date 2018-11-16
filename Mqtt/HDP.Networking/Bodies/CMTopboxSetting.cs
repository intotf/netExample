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
    /// 智能机顶盒控制体
    /// </summary>
    public class CMTopboxSetting : CMCtrlRequest
    {
        /// <summary>
        /// 控制参数
        /// </summary>
        [EnumDefined]
        public CMTopbox TbEnums { get; set; }
    }
}
