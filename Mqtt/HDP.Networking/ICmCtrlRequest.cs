using HDP.Networking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// 智能家居设备控制请求接口
    /// </summary>
    public interface ICMCtrlRequest : ITimeoutRequest
    {
        /// <summary>
        /// 中控机的设备id
        /// </summary>
        string Id { get; set; }
    }
}
