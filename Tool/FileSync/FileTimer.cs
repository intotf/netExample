using System;
using System.Threading;

namespace FileSync
{
    /// <summary>
    /// 文件同步定时器
    /// </summary>
    public class FileTimer
    {
        /// <summary>
        /// 同步定时器字典
        /// </summary>
        private readonly System.Collections.Concurrent.ConcurrentDictionary<string, Timer> cache;

        /// <summary>
        /// 延迟间隔
        /// </summary>
        public TimeSpan TimeSpan { get; private set; }

        /// <summary>
        /// 构造文件同步定时器
        /// </summary>
        /// <param name="timeSpan"></param>
        public FileTimer(TimeSpan timeSpan)
        {
            this.cache = new System.Collections.Concurrent.ConcurrentDictionary<string, Timer>(StringComparer.OrdinalIgnoreCase);
            this.TimeSpan = timeSpan;
        }

        /// <summary>
        /// 执行同步
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="action"></param>
        public void Invoke(string filePath, Action action)
        {
            var timer = cache.GetOrAdd(filePath, (file) =>
            {
                return new Timer((state) =>
                {
                    ((Action)state)();
                    Timer t;
                    if (cache.TryRemove(file, out t))
                    {
                        t.Dispose();
                    }
                }, action, this.TimeSpan, Timeout.InfiniteTimeSpan);

            });
            timer.Change(this.TimeSpan, Timeout.InfiniteTimeSpan);
        }
    }
}
