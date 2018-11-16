using HDP.Common.Utility;
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
    public class CMTempPassWordSetting2 : CMTempPassWordSetting
    {
        /// <summary>
        /// 生效时间类型
        /// </summary>
        [EnumDefined]
        public EffectMode EffectMode { get; set; }

        /// <summary>
        /// 经过指定秒数后生效
        /// </summary>
        public int EffectDelay { get; set; }

        /// <summary>
        /// 转换为EffectMode为Time的基础类型
        /// </summary>
        /// <returns></returns>
        public CMTempPassWordSetting WitchToTimeEffectMode()
        {
            var mapper = new Mapper(this);
            var target = mapper.To<CMTempPassWordSetting>();

            if (this.EffectMode == EffectMode.Delay)
            {
                target.EffectTime = DateTime.Now.AddSeconds(this.EffectDelay);
            }
            else if (target.EffectTime == null)
            {
                target.EffectTime = DateTime.Now;
            }
            return target;
        }
    }
}
