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
    /// 免扰开关
    /// </summary>
    public class CMImmunitySetting : CMCtrlRequest
    {
        /// <summary>
        /// 免扰开关
        /// </summary>
        [EnumDefined]
        public CMImmunity ImmunityEnums { get; set; }
    }
}
