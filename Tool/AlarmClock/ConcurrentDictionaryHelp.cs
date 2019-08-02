using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
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
}
