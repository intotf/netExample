using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class Program
    {

        /// <summary>
        /// Ip 地址
        /// </summary>
        static string ip = ConfigurationManager.AppSettings["ip"];

        /// <summary>
        /// 端口
        /// </summary>
        static int port = int.Parse(ConfigurationManager.AppSettings["port"]);

        /// <summary>
        /// Socket 服务
        /// </summary>
        private static Socket socketServer;

        /// <summary>
        /// 模拟数据
        /// </summary>
        static List<byte> data = new List<byte>();

        static void Main(string[] args)
        {
            var action = new byte[] { 0x01 };
            var body = File.ReadAllText("body.txt");
            var dataType = BitConverter.GetBytes(102);
            var bodyJosn = Encoding.Default.GetBytes(body);
            var len = action.Length + dataType.Length + bodyJosn.Length + 4;
            var length = BitConverter.GetBytes(len);

            data.AddRange(length);
            data.AddRange(action);
            data.AddRange(dataType);
            data.AddRange(bodyJosn);


            var client = new AppClient(ip, port);
            client.ReciveMessage = ReciveMessage;
            var d = 0;
            while (d < 1000)
            {
                d++;
                client.Send(data.ToArray());
                Task.Delay(1000).Wait();
            }


            Console.ReadKey();
        }

        static void ReciveMessage(byte[] buffer, int count)
        {
            if (buffer.Length > 0)
            {
                var msg = Encoding.Default.GetString(buffer, 0, count);
                Console.WriteLine("{0} 接收至服务端的消息:{1}", DateTime.Now, msg);
            }
        }


        ///<summary>  
        ///绑定地址并监听  
        ///</summary>  
        ///ip地址 端口 类型默认为TCP  
        static void init()
        {
            while (ConnectServer() == false) ;

            Task.Factory.StartNew(ReciveMsg);

            var i = 0;
            while (true)
            {
                Send(data.ToArray());
                Task.Delay(1000).Wait();
            }

            while (true)
            {
                var msg = Console.ReadLine();
                //发送消息
                if (!string.IsNullOrEmpty(msg))
                {
                    Send(msg);
                }
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        static void Send(string msg)
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
        static void Send(byte[] buffer)
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
        static bool ConnectServer()
        {
            try
            {
                Console.WriteLine("正在连接服务器......");
                var serverIp = new IPEndPoint(IPAddress.Parse(ip), port);
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketServer.Connect(serverIp);
                Console.WriteLine("服务器连接成功.");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 接收服务端的消息
        /// </summary>
        static void ReciveMsg()
        {
            byte[] buffer = new byte[1024 * 1024 * 5];//设置最多接收5M的信息
            while (true)
            {
                int count = 0;
                var msg = string.Empty;
                try
                {
                    count = socketServer.Receive(buffer);//把接收到的信息放在buffer中
                    if (count > 0)
                    {
                        msg += Encoding.Default.GetString(buffer, 0, count);
                        Console.WriteLine("{0} 接收至服务端的消息:{1}", DateTime.Now, msg);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} {1}", DateTime.Now, "与服务端断开连接");
                    socketServer.Close();
                    while (ConnectServer() == false)
                    {
                    }
                    break;
                }
            }
        }
    }
}
