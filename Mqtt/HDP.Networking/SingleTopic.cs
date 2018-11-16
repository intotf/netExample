using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// 表示单一终端主题
    /// </summary>
    public class SingleTopic : Topic
    {
        /// <summary>
        /// 获取终端的唯一标识
        /// </summary>
        public string UniqueId { get; private set; }

        /// <summary>
        /// 单一终端主题
        /// </summary>
        /// <param name="format">主题</param>
        /// <param name="uniqueId">终端的唯一标识</param>
        public SingleTopic(string format, string uniqueId)
            : base(format, uniqueId)
        {
            this.UniqueId = uniqueId;
        }
    }
}
