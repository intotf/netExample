using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Enums
{
    /// <summary>
    /// 情景模式类型
    /// </summary>
    public enum CMSceneMode
    {
        /// <summary>
        /// 撤防模式
        /// </summary>
        Disarm = 0,

        /// <summary>
        /// 布防模式
        /// </summary>
        Deploy = 1,

        /// <summary>
        /// 自定义情景模式
        /// </summary>
        Custom = 2,
    }
}
