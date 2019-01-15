using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;

namespace SocketLib
{
    public class SocketServer : ServerBase
    {
        /// <summary>
        /// 构造Socket服务端
        /// </summary>
        /// <param name="ip">服务端IP,默认为 0.0.0.0</param>
        /// <param name="port">指定端口</param>
        /// <param name="protocol">指定协议,默认 Tcp</param>

        public SocketServer(int port, string ip = "0.0.0.0", ProtocolType protocol = ProtocolType.Tcp)
            : base(port, ip, protocol)
        {
        }

        public List<SocketClient>

        
    }
}
