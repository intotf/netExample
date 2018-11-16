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
    /// 可调灯光设备
    /// </summary>
    public class CMDimmerSetting : CMCtrlRequest
    {
        /// <summary>
        /// 控制亮度值 
        /// </summary>
        [EnumDefined]
        public CMBrightness Brightness { get; set; }
    }
}
