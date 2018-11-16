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
    /// 单火线无线灯控开关
    /// </summary>
    public class CMSingleLightSetting : CMCtrlRequest
    {
        /// <summary>
        /// 控制指令 
        /// </summary>
        [EnumDefined]
        public CMSwitch IsOpen { get; set; }
    }
}
