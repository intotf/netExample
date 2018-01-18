using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// String 扩展
    /// 1、类必需加 static 关键字
    /// 2、方法必需加 static 关键字
    /// 3、必需包含一个参数 且前面需加 this 修饰
    /// </summary>
    public static class StringExtend
    {
        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object source)
        {
            if (source == null)
            {
                return true;
            }

            if (string.IsNullOrEmpty(source.ToString()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <param name="target">目标值</param>
        /// <returns></returns>
        public static T IsNullByDefault<T>(this T source, T target) where T : class,new()
        {
            if (source.IsNullOrEmpty())
            {
                return target;
            }
            return source;
        }
    }
}
