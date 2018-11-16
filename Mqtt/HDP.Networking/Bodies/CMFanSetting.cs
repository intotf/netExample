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
    /// 风扇
    /// </summary>
    public class CMFanSetting : CMCtrlRequest
    {
        /// <summary>
        /// 风速档/关 [0-5,表示关,1-5 表示开]
        /// </summary>
        [Range(0, 5)]
        public int WindSpeed { get; set; }

    }
}
