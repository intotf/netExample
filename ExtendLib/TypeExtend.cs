using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace System
{
    public static class TypeExtend
    {
        /// <summary>
        /// 获取对象指定特性第一个
        /// </summary>
        /// <returns></returns>
        [Obsolete("没什么必要")]
        public static T GetAttributeFirst<T>(this Type t) where T : Attribute
        {
            return t.GetAttribute<T>().FirstOrDefault();
        }

        /// <summary>
        /// 获取对象指定特性
        /// </summary>
        /// <returns></returns>
        [Obsolete("没什么必要")]
        public static IEnumerable<T> GetAttribute<T>(this Type t) where T : Attribute
        {
            var att = t.GetCustomAttributes<T>();
            if (att == null)
            {
                return null;
            }
            return att;
        }
    }
}
