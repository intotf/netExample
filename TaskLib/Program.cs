using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskLib
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(DateTime.Now + "任务开始.");
            //var waitTask = Task.Run(async () =>
            //{
            //    Console.WriteLine("Hello World!");
            //    await Task.Delay(10000);
            //});
            ////表示等待 5 秒中后退出阻塞过程
            //waitTask.Wait(TimeSpan.FromSeconds(5));
            //Console.WriteLine(DateTime.Now + "任务完成.");


            Console.WriteLine(DateTime.Now + "任务开始.");
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(3000);      // 设置任务取消时间

            //以下实例为：执行一个新的任务在3秒钟后取消，等待这个任务 5秒钟
            newTask(cts.Token)
                    //配置任务等待时间
                    .Wait(new CancellationTokenSource(5000).Token);

            // 如果在等待时间还未完成，将抛出异常；
            // 如果 .Wait(10000) 为时间类型，将返回 任务的执行 结果 bool

            Console.WriteLine(DateTime.Now + "任务完成.");

            Console.ReadKey();
        }

        /// <summary>
        /// 任务
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        static async Task newTask(CancellationToken token)
        {
            while (token.IsCancellationRequested == false)
            {
                Console.WriteLine("任务");
                await Task.Delay(1000);
            }
        }
    }
}
