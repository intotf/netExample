using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Enums
{
    /// <summary>
    /// 免扰开关 勿扰、清洁、稍等
    /// </summary>
    public enum CMImmunity
    {
        /// <summary>
        /// 勿扰
        /// </summary>
        NotDisturb = 0,

        /// <summary>
        /// 清洁
        /// </summary>
        Clean = 1,

        /// <summary>
        /// 稍等
        /// </summary>
        Wait = 2,
    }
}
