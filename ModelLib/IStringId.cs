using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    /// <summary>
    /// 默认ID
    /// 1.强制要求实体必需有一个 Id 属性
    /// </summary>
    public interface IStringId
    {
        /// <summary>
        /// ID
        /// </summary>
        string Id { get; set; }
    }
}
