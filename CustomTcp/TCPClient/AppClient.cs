using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    public class AppClient : IDisposable
    {
        private IPEndPoint iPEndPoint;

        private Socket socketServer;

        /// <summary>
        /// 服务端消息接收
        /// </summary>
        public Action<byte[], int> ReciveMessage;

        /// <summary>
        /// 构造客户端
        /// </summary>
        public AppClient(string ip, int port)
        {
            iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            while (ConnectServer() == false) ;
        }

        /// <summary>
        /// 接收服务端的消息
        /// </summary>
        private void ReciveMsg()
        {
            byte[] buffer = new byte[1024 * 1024];//设置最多接收1M的信息
            while (true)
            {
                int count = 0;
                var msg = string.Empty;
                try
                {
                    count = socketServer.Receive(buffer);//把接收到的信息放在buffer中
                    if (count > 0)
                    {
                        this.ReciveMessage.Invoke(buffer, count);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} {1}", DateTime.Now, "与服务端断开连接");
                    this.Dispose();
                    while (ConnectServer() == false) ;
                    break;
                }
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        public void Send(string msg)
        {
            var buffer = Encoding.Default.GetBytes(msg);
            try
            {
                socketServer.Send(buffer);
            }
            catch (Exception ex)
            {
                while (ConnectServer() == false) ;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        public void Send(byte[] buffer)
        {
            try
            {
                socketServer.Send(buffer);
            }
            catch (Exception ex)
            {
                while (ConnectServer() == false) ;
            }
        }

        /// <summary>
        /// 尝试连接服务端
        /// </summary>
        /// <returns></returns>
        private bool ConnectServer()
        {
            try
            {
                Console.WriteLine("正在连接服务器......");
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketServer.Connect(iPEndPoint);
                Console.WriteLine("服务器连接成功.");
                Task.Factory.StartNew(ReciveMsg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            socketServer.Close();
            socketServer.Dispose();
        }
    }
}
