using HDP.Model.Dtos;
using HDP.Model.Enums;
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
    /// 智能门锁-临时密码管理
    /// </summary>
    public class CMTempPassWordInfo : CMTempPassWordBody
    {
        /// <summary>
        /// 中控机的设备id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 中控机的设备类型
        /// </summary>
        [EnumDefined]
        public CMDeviceType Type { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [EnumDefined]
        public ActionType ActionType { get; set; }
    }
}
