using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleLib
{
    /// <summary>
    /// 安全线程缓存
    /// 可跨线程，只要进程不重启就不丢失。
    /// </summary>
    public class ConcurrentDictionaryHelp<T> where T : class
    {
        /// <summary>
        /// object 缓存
        /// ConcurrentDictionary 线程缓存，只要程序进程存在缓存就会一直存在。
        /// </summary>
        private static readonly ConcurrentDictionary<string, T> Caches = new ConcurrentDictionary<string, T>();

        /// <summary>
        /// 获取目前所以缓存数据
        /// </summary>
        /// <returns></returns>
        public static ConcurrentDictionary<string, T> GetAllCaches()
        {
            return Caches;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public static bool Add(string Key, T Value)
        {
            return Caches.TryAdd(Key, Value);
        }

        /// <summary>
        /// 添加/获取
        /// Key 不存在的情况下进行添加
        /// 否则获取 key 对应的值
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public static T GetOrAdd(string Key, T Value)
        {
            return Caches.GetOrAdd(Key, (k) => { return Value; });
        }

        /// <summary>
        /// 获取/如Key 不存在返回 default(T)
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static T Get(string Key)
        {
            T value = default(T);
            Caches.TryGetValue(Key, out value);
            return value;
            // Caches.GetOrAdd(Key, (k) => default(T));
        }

        /// <summary>
        /// 更新/添加
        /// 如果Key 不存在新增
        /// 如果存在进和修改
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        public static T AddOrUpdate(string Key, T value)
        {
            return Caches.AddOrUpdate(Key, value, (k, m) => value);
        }

        /// <summary>
        /// 更新值
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        public static bool Update(string Key, T value)
        {
            var oldValue = value;
            Caches.TryGetValue(Key, out oldValue);
            ///必需先的找出原来的值，通过 Key+Value 进行对比如果一致就更新
            return Caches.TryUpdate(Key, value, oldValue);
        }

        /// <summary>
        /// 删除 Key值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Delete(string key)
        {
            T value = default(T);
            return Caches.TryRemove(key, out value);
        }
    }

    /// <summary>
    /// 线程安全字典例子
    /// </summary>
    public class ConcurrentDictionaryHelp
    {
        /// <summary>
        /// 例子
        /// </summary>
        public async static void DemoRun()
        {
            Console.WriteLine("线程安全字典例子");
            var cacheKey = "test";
            ConcurrentDictionaryHelp<string>.Add(cacheKey, "初始值");

            //验证多线程对 ConcurrentDictionary 安全线程字典缓存做读写
            #region 方式一，使用 await,线程修改后，主线程获取的时候正常
            await Task.Factory.StartNew(() =>
            {
                var taskValue = ConcurrentDictionaryHelp<string>.Get(cacheKey);
                Console.WriteLine("Task 子线程序中，获取缓存内容 ：{0}", taskValue);
                Console.WriteLine("Task 正在修改值");
                var isupdate = ConcurrentDictionaryHelp<string>.Update(cacheKey, "Edit 后1");
            });
            Console.WriteLine("子线程序修改后，缓存内容 ：{0}", ConcurrentDictionaryHelp<string>.Get(cacheKey));
            #endregion

            #region 方式二，Task IsCompleted是否完成状态，如已完成就获取
            var task = Task.Factory.StartNew(() =>
            {
                var taskValue = ConcurrentDictionaryHelp<string>.Get(cacheKey);
                Console.WriteLine("Task 子线程序中，获取缓存内容 ：{0}", taskValue);
                Console.WriteLine("Task 正在修改值");
                ConcurrentDictionaryHelp<string>.Update(cacheKey, "Edit 后2");
            });
            var taskState = task.IsCompleted;
            while (!taskState)
            {
                taskState = task.IsCompleted;
                if (taskState)
                {
                    Console.WriteLine("子线程序修改后，缓存内容 ：{0}", ConcurrentDictionaryHelp<string>.Get(cacheKey));
                }
                Thread.Sleep(1);
            }
            #endregion
            var all = ConcurrentDictionaryHelp<string>.GetAllCaches();
            Console.WriteLine(string.Join(Environment.NewLine, all.Select(item => item.Key + ":" + item.Value).ToArray()));
            //ConcurrentDictionaryHelp<string>.Delete(cacheKey);
        }
    }
}
