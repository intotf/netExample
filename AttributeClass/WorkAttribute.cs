using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLib
{
    /// <summary>
    /// 工作特性
    /// 1.命名必需以 Attribute 结尾
    /// 2.必需继承 Attribute 基类
    /// 3.可以定义相关属性
    /// 4.AttributeUsage(设置特性继承约束,目前可使用在 Class 或 方法 上,不可重复)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class WorkAttribute : Attribute
    {
        /// <summary>
        /// 等级/排序
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 构造特性
        /// </summary>
        /// <param name="Level"></param>
        /// <param name="Code"></param>
        public WorkAttribute(int Level, string Code)
        {
            this.Level = Level;
            this.Code = Code;
        }
    }
}
