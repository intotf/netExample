using HDP.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// 定义超时请求
    /// </summary>
    public interface ITimeoutRequest
    {
        /// <summary>
        /// 超时的秒数
        /// 如果在Timeout秒之后才收到数据则不处理
        /// </summary>
        [Range(1, 30)]
        int Timeout { get; set; }
    }
}
