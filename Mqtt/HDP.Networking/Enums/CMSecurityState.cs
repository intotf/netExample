using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Enums
{
    /// <summary>
    /// 安防设备状态
    /// </summary>
    public enum CMSecurityState
    {
        /// <summary>
        /// 撤防
        /// </summary>
        Disarm = 0,

        /// <summary>
        /// 布防
        /// </summary>
        Deploy = 1,
    }
}
