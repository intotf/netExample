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
    /// 情景模式设置
    /// </summary>
    public class CMSceneSetting : ITimeoutRequest
    {
        /// <summary>
        /// 超时的秒数
        /// 如果在Timeout秒之后才收到数据则不处理
        /// </summary>
        [Range(1, 30)]
        public int Timeout { get; set; }

        /// <summary>
        /// 应用的情景模式id
        /// </summary>
        [Required]
        public string SceneId { get; set; }
    }
}
