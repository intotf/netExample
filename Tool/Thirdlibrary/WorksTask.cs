using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirdlibrary
{
    /// <summary>
    /// Task 多线程学习
    /// </summary>
    public class WorksTask
    {
        /// <summary>
        /// 列锁的方法
        /// </summary>
        private static void Run1()
        {
            Console.WriteLine("Task 1 Start running...");
            var i = 0;
            while (i > 10)
            {
                System.Threading.Thread.Sleep(1000);
                i++;
            }
            Console.WriteLine("Task 1 Finished!");
        }

        /// <summary>
        /// 等待2秒的方法
        /// </summary>
        private static void Run2()
        {
            Console.WriteLine("Task 2 Start running...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Task 2 Finished!");
        }

        /// <summary>
        /// 多线程运行
        /// </summary>
        public static void TaskRun()
        {
            //多线程运行，等待所有线程执行完
            //var t1 = Task.Factory.StartNew(Run1);
            //var t2 = Task.Factory.StartNew(Run2);
            //Task.WaitAll(t1, t2);
            var t1 = new Task[1] { Task.Factory.StartNew(Run1) };
            Task.WaitAll(t1, 5000);
            if (t1[0].Status != TaskStatus.RanToCompletion)
            {
                Console.WriteLine("Task  已超时!");
            }

            //改进对所有线程进行处理，超时时间为 1秒
            Task[] tasks = new Task[2];
            tasks[0] = Task.Factory.StartNew(Run1);
            tasks[1] = Task.Factory.StartNew(Run2);
            Task.WaitAll(tasks, 5000); //等待超时时间 单位毫秒
            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].Status != TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("Task {0} 已超时!", i + 1);
                }
            }
        }
    }
}
