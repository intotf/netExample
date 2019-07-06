using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiTaskAsync
{
    /// <summary>
    /// 多线程工作
    /// </summary>
    public class Workers
    {
        /// <summary>
        /// 数据总数
        /// </summary>
        private long total = 0;

        /// <summary>
        /// 当前进度
        /// </summary>
        private long current = 0;


        /// <summary>
        /// 多线程锁
        /// </summary>
        private readonly AsyncRoot root = new AsyncRoot(50);

        /// <summary>
        /// 执行对象操作
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public async Task RunAsync<T>(IEnumerable<T> datas)
        {
            this.total = datas.Count();
            var tasks = datas.Select(item => RunOneAsync(item));
            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// 单条数据处理
        /// 假设处理一条数据100 毫秒
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private async Task RunOneAsync<T>(T data)
        {
            using (await root.LockAsync())
            {
                await Task.Delay(100);
                Interlocked.Increment(ref current);
                Console.Title = $"{current}/{total}";
            }
        }
    }
}
