using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperMode
{
    /// <summary>
    /// 隐式转换
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ImplicitResult<T>
    {
        /// <summary>
        /// 获取或设置数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 从data转换得到
        /// </summary>
        /// <param name="data"></param>
        public static implicit operator ImplicitResult<T>(T data)
        {
            return new ImplicitResult<T>
            {
                Data = data
            };
        }
    }

    // <summary>
    /// 隐式转换
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExplicitResult<T>
    {
        /// <summary>
        /// 获取或设置数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 从data转换得到
        /// </summary>
        /// <param name="data"></param>
        public static explicit operator ExplicitResult<T>(T data)
        {
            return new ExplicitResult<T>
            {
                Data = data
            };
        }
    }
}
