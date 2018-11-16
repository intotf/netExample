using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Enums
{
    /// <summary>
    /// 中控机设备核心参数类型
    /// </summary>
    public enum CMCoreParamType
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,

        /// <summary>
        /// 温度
        /// </summary>
        Temperature = 1,

        /// <summary>
        /// 亮度
        /// </summary>
        Brightness = 2,

        /// <summary>
        /// 湿度
        /// </summary>
        Humidity = 3,

        /// <summary>
        /// 高度
        /// </summary>
        Height = 4,

        /// <summary>
        /// 长度
        /// </summary>
        Length = 5,

        /// <summary>
        /// 厚度
        /// </summary>
        Thickness = 6,

        /// <summary>
        /// 音量
        /// </summary>
        Volume = 7,

        /// <summary>
        /// 宽度
        /// </summary>
        Width = 8,
    }
}
