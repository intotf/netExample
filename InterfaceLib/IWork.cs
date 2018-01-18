using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    /// <summary>
    /// 定义一个工作接口
    /// </summary>
    public interface IWork
    {
        /// <summary>
        /// 开始时间
        /// 接口可添加字段，可定义方法名
        /// </summary>
        DateTime TimeNow { get; }

        /// <summary>
        /// 上班
        /// </summary>
        void OnWork();

        /// <summary>
        /// 异步上班
        /// </summary>
        /// <returns></returns>
        Task<bool> OnWorkAsync();
    }
}
