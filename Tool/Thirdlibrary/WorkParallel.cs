using AbstractLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thirdlibrary
{
    /// <summary>
    /// 并行操作
    /// </summary>
    public class WorkParallel
    {
        private static WorkOne workOne = new WorkOne(new Worker("张三") { Age = 18 });

        private static WorkTwo workTwo = new WorkTwo(new Worker("李四") { Age = 22 });

        /// <summary>
        /// 时间统计器
        /// </summary>
        private static Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        /// 等待 2秒
        /// </summary>
        private static void Run1()
        {
            Thread.Sleep(2000);
            workOne.DoWork();
        }

        /// <summary>
        /// 等待3秒
        /// </summary>
        private static void Run2()
        {
            Thread.Sleep(3000);
            workTwo.DoWork();
        }

        /// <summary>
        /// 并行运行
        /// 正常一步步操作的话需要 5秒钟，如果并行操作的话一般少于 5秒大于 最大的一次执行时间3秒；
        /// </summary>
        public static void ParallelInvokeMethod()
        {
            stopWatch.Start();
            Parallel.Invoke(Run1, Run2);

            stopWatch.Stop();
            Console.WriteLine("并行运行结果： " + stopWatch.ElapsedMilliseconds + " ms.");
            stopWatch.Restart();
            Run1();
            Run2();
            stopWatch.Stop();
            Console.WriteLine("正常顺序运结果： " + stopWatch.ElapsedMilliseconds + " ms.");
        }

        /// <summary>
        /// 计算1-1000 累加结果
        /// 每次计算间隔1 毫秒，相当于比较复杂的一些业务逻辑，比如：读写数据库之类的
        /// 结果显示并行要大大优越于 for
        /// Interlocked  原子操作,保持在循环中保护 cNum 值
        /// </summary>
        public static void ParallelTask()
        {
            #region For循环,同步操作
            List<int> data = new List<int>();
            for (int i = 1; i <= 1000; i++)
            {
                data.Add(i);
            }
            stopWatch.Reset();
            int cNum = 0;
            stopWatch.Start();
            for (int i = 0; i < data.Count; i++)
            {
                cNum += data[i];
                Thread.Sleep(1);
            }
            stopWatch.Stop();
            Console.WriteLine("执行 {0} 至 {1} For循环累加总和为：{2},总共计算时间：{3} ms.", data.Min().ToString(), data.Max().ToString(), cNum, stopWatch.ElapsedMilliseconds);
            #endregion

            #region 并行操作
            var feData = new List<string>();
            cNum = 0;
            stopWatch.Reset();
            stopWatch.Start();
            Parallel.ForEach(data, (n) =>
            {
                //原子操作,保持在循环中保护 cNum 值
                Interlocked.Add(ref cNum, n);
                Thread.Sleep(1);
                //Console.WriteLine(cNum);
            });
            stopWatch.Stop();
            Console.WriteLine("并行执行 {0} 至 {1} 累加总和为：{2},总共计算时间：{3} ms.", data.Min().ToString(), data.Max().ToString(), cNum, stopWatch.ElapsedMilliseconds);
            #endregion
        }
    }
}
