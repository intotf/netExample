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
    /// 智能门锁-临时密码管理
    /// </summary>
    public class CMTempPassWordSetting : CMCtrlRequest
    { 
        /// <summary>
        /// 操作类型
        /// </summary>
        [EnumDefined]
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 密码ID
        /// </summary>
        public string PwdID { get; set; }

        /// <summary>
        /// 临时密码(不可重复,如重复不处理)
        /// </summary>
        public string TempPWD { get; set; }

        /// <summary>
        /// 在指定的时间点生效
        /// (年月日 时分)
        /// </summary>
        public DateTime? EffectTime { get; set; }



        /// <summary>
        /// 有效时长(小时 0.5,1,2,3,4 小时)
        /// </summary>
        [Range(0.5d, 4d)]
        public float EffectiveTime { get; set; }

        /// <summary>
        /// 有效次数(1-5)
        /// </summary>
        [Range(1, 5)]
        public int EffectiveNum { get; set; }

        /// <summary>
        /// 临时密码状态
        /// </summary>
        [Required(ErrorMessage = "临时密码状态不能为空")]
        [EnumDefined]
        public TempPWDState State { get; set; }
    }
}
