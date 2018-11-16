using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// 表示emqttd的客户端信息
    /// </summary>
    public class ClientInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// ip地址
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 是否清除会话
        /// </summary>
        public bool Clean_sess { get; set; }
        /// <summary>
        /// 协议版本
        /// </summary>
        public int Proto_ver { get; set; }
        /// <summary>
        /// 心跳时间
        /// </summary>
        public int Keepalive { get; set; }
        /// <summary>
        /// 连接时间
        /// </summary>
        public DateTime Connected_at { get; set; }
    }
}
