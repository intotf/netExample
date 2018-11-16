using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Enums
{
    /// <summary>
    /// 新风系统 - 三种模式(冷、热、湿度)
    /// </summary>
    public enum CMFreshAirMode
    {
        /// <summary>
        /// 制冷
        /// </summary>
        cold = 0,

        /// <summary>
        /// 制热
        /// </summary>
        Hot = 1,

        /// <summary>
        /// 湿度
        /// </summary>
        humidity = 2
    }
}
