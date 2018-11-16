using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 中控机的设备数据
    /// </summary>
    public class CMDeivceData
    {
        /// <summary>
        /// 获取或设置所有设备
        /// </summary>
        public CMDeviceInfo[] Devices { get; set; }

        /// <summary>
        /// 获取或设置所有房间
        /// </summary>
        public CMRoomInfo[] Rooms { get; set; }
    }
}
