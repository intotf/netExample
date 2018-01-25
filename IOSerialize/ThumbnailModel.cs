using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize
{
    /// <summary>
    /// 缩率图处理模式
    /// </summary>
    public enum ThumbnailModel
    {
        /// <summary>
        /// 指定高宽缩放（可能变形）   
        /// </summary>
        HighWidth,

        /// <summary>
        /// 指定宽，高按比例   
        /// </summary>
        Width,

        /// <summary>
        /// 默认  全图不变形   
        /// </summary>
        Default,

        /// <summary>
        /// 指定高，宽按比例
        /// </summary>
        Hight,

        /// <summary>
        /// 指定高宽裁减（不变形）？？指定裁剪区域
        /// </summary>
        Cut,

        /// <summary>
        /// 自动 原始图片按比例缩放
        /// </summary>
        Auto
    }
}
