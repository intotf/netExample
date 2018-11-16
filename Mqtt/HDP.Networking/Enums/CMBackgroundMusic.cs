using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Enums
{
    /// <summary>
    /// 背景音乐
    /// </summary>
    public enum CMBackgroundMusic
    {
        /// <summary>
        /// 关机
        /// </summary>
        Off = 0,

        /// <summary>
        /// 开机
        /// </summary>
        On = 1,

        /// <summary>
        /// 静音
        /// </summary>
        Mute = 2,

        /// <summary>
        /// 播放暂停
        /// </summary>
        PlayPause = 3,

        /// <summary>
        /// 音量加
        /// </summary>
        VolAdd = 4,

        /// <summary>
        /// 音量减
        /// </summary>
        VolMinus = 5,

        /// <summary>
        /// 循环模式
        /// </summary>
        CycleMode = 6,

        /// <summary>
        /// 随机模式
        /// </summary>
        StochasticModel = 7,

        /// <summary>
        /// 上一个专辑
        /// </summary>
        CHAdd = 8,

        /// <summary>
        /// 下一个专辑
        /// </summary>
        CHMinus = 9,

        /// <summary>
        /// 上一首
        /// </summary>
        LastSong = 10,

        /// <summary>
        /// 下一首
        /// </summary>
        NextSong = 11,
    }
}
