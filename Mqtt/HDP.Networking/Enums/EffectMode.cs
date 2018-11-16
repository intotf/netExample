using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Enums
{
    /// <summary>
    /// 生效时间类型
    /// </summary>
    public enum EffectMode
    {
        /// <summary>
        /// 在指定的时间点生效
        /// EffectTime字段的值有效
        /// </summary>
        Time = 0,

        /// <summary>
        /// 在经过指定时间戳之后生效
        /// EffectDelay字段的值有效
        /// </summary>
        Delay = 1,
    }
}
