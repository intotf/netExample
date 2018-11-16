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
    /// 智能家居-开锁记录
    /// </summary>
    public class CMOpenRecordInfo
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
        /// 钥匙标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 开门类型
        /// </summary>
        [EnumDefined]
        public SmartLockType OpenType { get; set; }

        /// <summary>
        /// 开门时间
        /// </summary>
        public DateTime OpenTime { get; set; }
    }
}
