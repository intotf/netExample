using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskAsync
{
    /// <summary>
    /// 多线程锁任务处理
    /// </summary>
    class Program
    {
        /// <summary>
        /// 多线程锁 ,100个线程处理
        /// </summary>
        private static readonly AsyncRoot root = new AsyncRoot(100);


        static void Main(string[] args)
        {
            //构造 1万 int 数据
            var datas = Enumerable.Range(0, 10000).OrderBy(x => Guid.NewGuid());

            var sw = new Stopwatch();
            sw.Start();
            new Workers().RunAsync(datas).Wait();
            Console.WriteLine($"总共耗时：{sw.ElapsedMilliseconds} ms.");
            sw.Stop();

            Console.ReadKey();
        }
    }
}
