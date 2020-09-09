using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPServer
{
    public class SocketClient : IDisposable
    {
        private Socket socket;

        public string TagId { get; set; }

        /// <summary>
        /// 构造Socket客户端的连接
        /// </summary>
        /// <param name="socket">客户端连接信息</param>
        /// <param name="tagId">客户端标签</param>
        /// <param name="timeOut">连接超时时间</param>
        public SocketClient(Socket socket, string tagId = null, int timeOut = 0)
        {
            this.socket = socket;
            this.TagId = tagId ?? socket.RemoteEndPoint.ToString();
            socket.ReceiveTimeout = timeOut;
            Console.WriteLine("{0} {1} {2}", DateTime.Now, this.TagId, "连接成功.");
            var task = Task.Factory.StartNew(ReciveMsg);
            this.Send(TagId + " 连接成功.");
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
        private void Send(byte[] buffer)
        {
            try
            {
                socket.Send(buffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} {1} {2}", DateTime.Now, this.TagId, "断开连接,消息发送失败.");
                Program.socketClients.Remove(this);
                socket.Close();
            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        private void ReciveMsg()
        {
            var listBuffer = new List<byte>();
            byte[] buffer = new byte[48];//设置最多接收5M的信息
            while (true)//这里我们循环接收客户端的信息，客户端可以一直发信息,我们创建线程的好处就在这里，因为主线程一旦陷入死循环，那么这个程序就卡了
            {
                int count = 0;
                var msg = string.Empty;
                try
                {
                    count = socket.Receive(buffer);//把接收到的信息放在buffer中
                    if (count > 0)
                    {
                        var model = RunProtocol(buffer, count);
                        if (model != null)
                        {
                            Console.WriteLine("{0} 接收至[{1}]的消息:{2}", DateTime.Now, this.TagId, model);
                        }
                    }
                    else
                    {
                        this.Dispose();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    this.Dispose();
                    break;
                }
            }
        }

        private static List<byte> listBuffer = new List<byte>();

        private static TcpModel model = new TcpModel();

        /// <summary>
        /// 自定义协议
        /// 前面 1-4 表示本次数据长度
        /// 5 数值 0 新增 1 编辑 2 更新
        /// 6-9 类型 101 地区 102 人员 103 设备
        /// 9 - N 字符串 Json实体
        /// </summary>
        /// <returns></returns>
        private TcpModel RunProtocol(byte[] buffer, int count)
        {
            listBuffer.AddRange(buffer.Take(count).Select(item => item));
            if (listBuffer.Count >= 4)
            {
                model.Length = BitConverter.ToInt32(listBuffer.Take(4).ToArray(), 0);
            }

            if (listBuffer.Count >= model.Length && model.Length > 0)
            {
                model.Action = (ActType)listBuffer.Skip(4).Take(1).ToArray().FirstOrDefault();
                model.DataType = (DataType)BitConverter.ToInt32(listBuffer.Skip(5).Take(4).ToArray(), 0);
                model.BodyJson = Encoding.Default.GetString(listBuffer.Skip(9).Take(model.Length - 9).ToArray());
                listBuffer = listBuffer.Skip(model.Length).ToList();
                return model;
            }
            return null;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            listBuffer.Clear();
            Console.WriteLine("{0} {1} {2}", DateTime.Now, this.TagId, "断开连接");
            Program.socketClients.Remove(this);
            socket.Close();
            socket.Dispose();
        }
    }
}
