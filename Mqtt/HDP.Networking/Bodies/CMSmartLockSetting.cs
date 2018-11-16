using HDP.Model.Dtos;
using HDP.Model.Enums;
using HDP.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 智能门锁-钥匙管理
    /// </summary>
    public class CMSmartLockSetting : CMCtrlRequest
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        [EnumDefined]
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 钥匙Id
        /// </summary>
        public string PwdId { get; set; }

        /// <summary>
        /// 钥匙类型
        /// </summary>
        [Required(ErrorMessage = "钥匙类型不能为空")]
        [EnumDefined]
        public SmartLockType keyType { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Label { get; set; }
    }
}
