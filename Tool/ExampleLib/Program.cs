using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ExampleLib
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 同时执行两种检测网络是否可上网
            //var taskList = new List<Task>();
            //taskList.Add(Task.Factory.StartNew(NetworkLine.RunDemo1));
            //taskList.Add(Task.Factory.StartNew(NetworkLine.RunDemo2));
            //Task.WaitAll(taskList.ToArray());
            #endregion
            //线程安全字典例子
            //ConcurrentDictionaryHelp.DemoRun();

            //TimeSpanHelp 定时操作
            var timeHelp = TimeSpanHelp.Instance();

            //SystemTimer.Demo();
            //Console.WriteLine("SystemTimer 还在执行中.");
            //timeHelp.TimerDemo(TimeSpan.FromSeconds(3));
            //timeHelp.CancellationDeme(TimeSpan.FromSeconds(3));
            //var ts = TimeSpanHelp.Instance().GetSubtract(DateTime.Now, DateTime.Now.AddMilliseconds(25));


            //结构体
            //StructLib myStruct = new StructLib() { Id = 1314, Name = "皓月青峰" };
            //myStruct.Id = 123;
            //myStruct.Name = "张三";
            //Console.WriteLine(myStruct.ToString());
            //Console.WriteLine(new StructLib().ToString());
            Console.ReadKey();
        }

        static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("间隔执行");
        }
    }

}
