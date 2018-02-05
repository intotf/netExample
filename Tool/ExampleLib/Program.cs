using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLib
{
    class Program
    {
        static void Main(string[] args)
        {
            //线程安全字典例子
            //ConcurrentDictionaryHelp.DemoRun();

            //TimeSpanHelp
            var timeHelp = TimeSpanHelp.Instance();
            //timeHelp.TimerDemo(TimeSpan.FromSeconds(3));
            timeHelp.CancellationDeme(TimeSpan.FromSeconds(3));

            var ts = TimeSpanHelp.Instance().GetSubtract(DateTime.Now, DateTime.Now.AddMilliseconds(25));

            Console.ReadKey();
        }
    }

}
