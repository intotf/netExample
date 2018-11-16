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
    /// 背景音乐设备
    /// </summary>
    public class CMBackgroundMusicSetting : CMCtrlRequest
    {
        /// <summary>
        /// 开关参数
        /// </summary>
        [EnumDefined]
        public CMBackgroundMusic bmEnums { get; set; }
    }
}
