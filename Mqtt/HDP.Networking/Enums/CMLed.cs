using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Enums
{
    /// <summary>
    /// 恒亦明LED控制器
    /// </summary>
    public enum CMLed
    {
        /// <summary>
        /// 关
        /// </summary>
        OnOff = 0,

        /// <summary>
        /// 开
        /// </summary>
        On = 1,

        /// <summary>
        /// 待机
        /// </summary>
        Dormancy = 2,

        /// <summary>
        /// 亮度加
        /// </summary>
        BrightnessAdd = 3,

        /// <summary>
        /// 亮度减
        /// </summary>
        BrightnessMinus = 4,

        /// <summary>
        /// 色温加
        /// </summary>
        ColorTempAdd = 5,

        /// <summary>
        /// 色温减
        /// </summary>
        ColorTempMinus = 6,

        /// <summary>
        /// 全组模式
        /// </summary>
        AllGroup = 7,

        /// <summary>
        /// 灯组1模式
        /// </summary>
        GroupOne = 8,

        /// <summary>
        /// 灯组2模式
        /// </summary>
        GroupTwo = 9,

        /// <summary>
        /// 灯组3模式
        /// </summary>
        GroupThree = 10,

        /// <summary>
        /// 灯组4模式
        /// </summary>
        GroupFour = 11,

        /// <summary>
        /// 灯组5模式
        /// </summary>
        GroupFive = 12,


    }
}
