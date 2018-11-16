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
    /// 红外电视控制或学习
    /// </summary>
    public class CMInfTvKeyCtrl : CMCtrlRequest
    {
        /// <summary>
        /// 控制按键
        /// </summary>
        [EnumDefined]
        public CMInfTvKey Key { get; set; }

    }
}
