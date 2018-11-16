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
    /// 中控机设备报警
    /// </summary>
    public class CMAlarmInfo
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
        /// 报警时间
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 报警内容
        /// </summary>
        public string AlarmContent { get; set; }

        /// <summary>
        /// 报警类型
        /// </summary>
        public CmAlarmType AlertType { get; set; }
    }
}
