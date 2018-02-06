using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLib
{
    /// <summary>
    /// 结构体(一种值类型)
    /// 1、结构体就是一个可以包含不同数据类型的一个结构.它是一种可以自己定义的数据类型.
    /// 2、结构体可以在一个结构中声明不同的数据类型.
    /// 3、相同结构的结构体变量是可以相互赋值的.
    /// 4、节省内存空间
    /// 5、结构式值类型，其值存储在堆栈上，空间上浪费些(如果有多个实例). 效率比较好。
    /// 6. 结构可以指定内存的layout.
    /// 注：结构体一般使用在简单对象如：Int32，而不是偏向于"面向对象"，通常使用 class 就好了
    /// </summary>
    public struct StructLib
    {

        /// <summary>
        /// 定义字段
        /// </summary>
        public int Id;

        /// <summary>
        /// 定义字段
        /// </summary>
        public string Name;

        /// <summary>
        /// 定义方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id:{0},Name:{1}", this.Id, this.Name);
        }
    }
}
