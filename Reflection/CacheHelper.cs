using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class CacheHelper
    {
        /// <summary>
        /// object 缓存
        /// </summary>
        private static readonly ConcurrentDictionary<string, object> Caches = new ConcurrentDictionary<string, object>();


        public static object Get(string Key, object Value)
        {
            return Caches.GetOrAdd(Key, Value);
        }

        public static bool GetValue(string Key)
        {
            Caches.GetOrAdd(Key, (k, v) => k == Key);
        }
    }
}
