﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPServer
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
        /// 所有客户端
        /// </summary>
        public static List<SocketClient> socketClients = new List<SocketClient>();

        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            init();
        }

        ///<summary>  
        ///绑定地址并监听  
        ///</summary>  
        ///ip地址 端口 类型默认为TCP  
        static void init()
        {
            try
            {
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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

            #region 设置控制台输入最大值
            ///最多只能使用256个字符,它将允许输入254，并为CR和LF保留2。
            ///StreamReader 还必须具有长度参数，因为它也具有固定的缓冲区。
            byte[] inputBuffer = new byte[1024];
            var inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            #endregion

            while (true)
            {
                var msg = Console.ReadLine();
                if (!string.IsNullOrEmpty(msg))
                {
                    foreach (var client in socketClients)
                    {
                        client.Send(msg);
                    }
                }
            }
        }

        ///<summary>  
        ///监听用户连接  
        ///</summary>  
        static void ListenAccept()
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
    }
}
