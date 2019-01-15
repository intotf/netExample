using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;

namespace SocketLib
{

    public abstract class ServerBase
    {
        /// <summary>
        /// Socket 服务
        /// </summary>
        protected Socket socketServer;

        /// <summary>
        /// 所有客户端
        /// </summary>
        public List<SocketClient> socketClients = new List<SocketClient>();

        /// <summary>
        /// 构造Socket服务端
        /// </summary>
        /// <param name="ip">服务端IP,默认为 0.0.0.0</param>
        /// <param name="port">指定端口</param>
        /// <param name="protocol">指定协议,默认 Tcp</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="SocketException"></exception>

        public ServerBase(int port, string ip, ProtocolType protocol)
        {
            try
            {
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, protocol);
                socketServer.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                Task.Run(() => ListenAccept());
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 监听用户连接  
        /// </summary>
        private void ListenAccept()
        {
            socketServer.Listen(0);
            while (true)
            {
                //对于socketServer绑定的IP和端口开启监听  
                var socket = socketServer.Accept();                //如果在socketServer上有新的socket连接，则将其存入sTemp，并添加到链表  
                if (socket != null)
                {
                    socketClients.Add(new SocketClient(socket));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class SocketClient : IDisposable
        {
            /// <summary>
            /// Socket 服务
            /// </summary>
            private Socket socketClient;

            /// <summary>
            /// 客户端唯一标识
            /// </summary>
            public string TagId { get; set; }

            /// <summary>
            /// 构造Socket客户端的连接
            /// </summary>
            /// <param name="socket">客户端连接信息</param>
            /// <param name="timeOut">连接超时时间</param>
            public SocketClient(Socket socket, string tagId = null, int timeOut = 0)
            {
                this.socketClient = socket;
                this.TagId = tagId ?? socket.RemoteEndPoint.ToString();
                socket.ReceiveTimeout = timeOut;
            }

            /// <summary>
            /// 发送消息
            /// </summary>
            /// <param name="msg"></param>
            /// <returns></returns>
            public void Send(string msg)
            {
                var buffer = Encoding.Default.GetBytes(msg);
                Console.WriteLine("{0} 向客户端[{1}]发送:{2}", DateTime.Now, this.TagId, msg);
                this.Send(buffer);
            }

            /// <summary>
            /// 发送消息
            /// </summary>
            /// <param name="buffer"></param>
            public void Send(byte[] buffer)
            {
                try
                {
                    socketClient.Send(buffer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} {1} {2}", DateTime.Now, this.TagId, "断开连接,消息发送失败.");

                }
            }

            /// <summary>
            /// 释放客户连接
            /// </summary>
            public void Dispose()
            {
                socketClient.Close();
                socketClient.Dispose();
            }
        }
    }
}
