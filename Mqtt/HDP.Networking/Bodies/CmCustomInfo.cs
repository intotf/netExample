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
    /// 自定义消息通知
    /// </summary>
    public class CmCustomInfo
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
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
    }
}
