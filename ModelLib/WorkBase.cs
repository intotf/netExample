using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    /// <summary>
    /// 人员基本属性
    /// </summary>
    public class WorkBase
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 基类方法
        /// </summary>
        public void ToBase()
        {
            Console.WriteLine("{0} {1},我是一个基类方法", this.Name, this.Age);
        }

        public override string ToString()
        {
            Console.WriteLine("{0} {1},我是一个基类方法", this.Name, this.Age);
            return string.Format("{0} {1},我是一个基类方法", this.Name, this.Age);
        }
    }
}
