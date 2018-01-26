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
            ConcurrentDictionaryHelp.DemoRun();




            Console.ReadKey();
        }
    }

}
