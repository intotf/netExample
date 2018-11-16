using HDP.Networking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 中控机的设备
    /// </summary>
    public class CMDeviceInfo
    {
        /// <summary>
        /// 标识符
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public CMDeviceType Type { get; set; }


        /// <summary>
        /// 所在房间Id
        /// </summary>
        public int RoomId { get; set; }


        /// <summary>
        /// 开关状态
        /// </summary>
        public CMSwitch SwitchState { get; set; }


        /// <summary>
        /// 核心参数类型
        /// </summary>
        public CMCoreParamType CoreParamType { get; set; }

        /// <summary>
        /// 核心参数值 
        /// </summary>
        public int CoreParamvalue { get; set; }
    }
}
