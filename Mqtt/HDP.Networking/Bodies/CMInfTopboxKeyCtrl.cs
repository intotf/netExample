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
    /// 红外电机顶盒控制或学习
    /// </summary>
    public class CMInfTopboxKeyCtrl : CMCtrlRequest
    {
        /// <summary>
        /// 控制按键
        /// </summary>
        [EnumDefined]
        public CMInfTopboxKey Key { get; set; }
    }
}
