using HDP.Networking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking.Bodies
{
    /// <summary>
    /// 中控机情景模式
    /// </summary>
    public class CMSceneInfo
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
        /// 情景模式类型
        /// </summary>
        public CMSceneMode Mode { get; set; }

        /// <summary>
        /// 是否为当前情景
        /// </summary>
        public bool IsActive { get; set; }
    }
}
