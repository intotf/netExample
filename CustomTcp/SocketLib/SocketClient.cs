using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketLib
{
    public class SocketClient : IDisposable
    {
        /// <summary>
        /// Socket 服务
        /// </summary>
        private Socket socketClient;

        /// <summary>
        /// 构造Socket客户端的连接
        /// </summary>
        /// <param name="socket">客户端连接信息</param>
        /// <param name="tagId">客户端标签</param>
        /// <param name="timeOut">连接超时时间</param>
        public SocketClient(Socket socket, string tagId = null, int timeOut = 0)
        {
            this.socketClient = socket;
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
        /// 接收客户端的数据
        /// </summary>
        public void ReciveMsg()
        {
            int count = 0;
            var buffer = new byte[1024 * 1024];
            var msg = string.Empty;
            try
            {
                count = socketClient.Receive(buffer);//把接收到的信息放在buffer中
                if (count > 0)
                {
                    Console.WriteLine("{0} 接收至[{1}]的消息:{2}", DateTime.Now, this.TagId, model);
                }
                else
                {

                    Console.WriteLine("{0} {1} {2}", DateTime.Now, this.TagId, "断开连接");
                    Program.socketClients.Remove(this);
                    socket.Close();
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} {1} {2}", DateTime.Now, this.TagId, "断开连接");
                Program.socketClients.Remove(this);
                socket.Close();
                break;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="buffer"></param>
        private void Send(byte[] buffer)
        {
            socketClient.Send(buffer);
        }

        public void Dispose()
        {
            socketClient.Close();
            socketClient.Dispose();
        }
    }
}
