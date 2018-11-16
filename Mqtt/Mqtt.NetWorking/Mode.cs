using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.NetWorking
{
    /// <summary>
    /// 表示消息模式枚举
    /// </summary>
    [Flags]
    public enum Mode : byte
    {
        /// <summary>
        /// 发送且希望返回
        /// 1
        /// </summary>
        Send = 0x1,

        /// <summary>
        /// 投递，不需要回复
        /// 2
        /// </summary>
        Post = 0x2,

        /// <summary>
        /// 返回
        /// 4
        /// </summary>
        Return = 0x4
    }
}
