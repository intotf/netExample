using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtend
    {
        /// <summary>
        /// 获取DisplayAttribute 特性的Name
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum e)
        {
            if (e == null)
            {
                return null;
            }

            var display = e.GetAttribute<DisplayAttribute>();
            if (display == null)
            {
                return e.ToString();
            }
            return display.Name;
        }

        /// <summary>
        /// 获取DisplayAttribute 特性的Description
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDisplayDescription(this Enum e)
        {
            if (e == null)
            {
                return null;
            }

            var display = e.GetAttribute<DisplayAttribute>();
            if (display == null)
            {
                return e.ToString();
            }
            return display.Description;
        }


        /// <summary>
        /// 获取指定特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Enum e) where T : class
        {
            var field = e.GetType().GetField(e.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(T)) as T;
            return attribute;
        }
    }
}
