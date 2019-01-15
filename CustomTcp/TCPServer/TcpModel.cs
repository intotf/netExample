using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    /// <summary>
    /// 自定义协议实体
    /// </summary>
    public class TcpModel
    {
        /// <summary>
        /// 总长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public ActType Action { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public DataType DataType { get; set; }

        /// <summary>
        /// 实体 Json
        /// </summary>
        public string BodyJson { get; set; }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("操作类型:{0},数据类型:{1},实体Json:{2}", this.Action, this.DataType, this.BodyJson);
        }
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum ActType
    {
        /// <summary>
        /// 添加
        /// </summary>
        Add = 0x00,
        /// <summary>
        /// 更新
        /// </summary>
        Update = 0x01,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 0x02,
    }

    public enum DataType
    {
        /// <summary>
        /// 地区
        /// </summary>
        Area = 101,

        /// <summary>
        /// 住户
        /// </summary>
        House = 102,
    }
}
