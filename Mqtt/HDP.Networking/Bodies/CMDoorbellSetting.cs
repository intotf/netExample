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
    /// 无线门铃
    /// </summary>
    public class CMDoorbellSetting : CMCtrlRequest
    {
        /// <summary>
        /// 开关控制 [开 true/关 false]
        /// </summary>
        public bool IsOpen { get; set; }
    }
}
