using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleLib
{
    /// <summary>
    /// 检测当前电脑网络是否正常
    /// </summary>
    public class NetworkLine
    {

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(int Description, int ReservedValue);

        #region 方法一，有缺陷（用手机共享热点连接，显示可以上网，断开手机 4G流量还是可以上网）
        /// <summary>
        /// 用于检查网络是否可以连接互联网,true表示连接成功,false表示连接失败
        /// </summary>
        /// <returns></returns>
        private static bool IsConnectInternet()
        {
            int Description = 0;
            return InternetGetConnectedState(Description, 0);
        }
        #endregion 方法一

        #region 方法二，使用Ping 方式检测是否可上网(比较及时缺陷就是需要指定网址或IP)
        /// <summary>
        /// ping 方法检测是否可上网
        /// </summary>
        /// <returns></returns>
        private static bool PingOnLine()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            try
            {
                System.Net.NetworkInformation.PingReply pr = ping.Send("www.baidu.com", 1000);
                return pr.Status == System.Net.NetworkInformation.IPStatus.Success;
            }
            catch
            {
            }
            return false;
        }
        #endregion


        public static void RunDemo1()
        {
            while (true)
            {
                if (NetworkLine.IsConnectInternet())
                {
                    Console.WriteLine("wininet 网络正常");
                }
                else
                {
                    Console.WriteLine("wininet 网络连接失败");
                }
                Thread.Sleep(500);
            }
        }

        public static void RunDemo2()
        {
            while (true)
            {
                if (NetworkLine.PingOnLine())
                {
                    Console.WriteLine("Ping 网络正常");
                }
                else
                {
                    Console.WriteLine("Ping 网络连接失败");
                }
                Thread.Sleep(500);
            }
        }
    }
}
