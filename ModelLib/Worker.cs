using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    /// <summary>
    /// 工作者实体
    /// </summary>
    public class Worker : WorkBase, IStringId
    {
        public Worker()
        {

        }

        public Worker(string Name)
        {
            this.Name = Name;
        }

        /// <summary>
        /// ID编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public WorkType workType { get; set; }

        /// <summary>
        /// 实体中的方法
        /// </summary>
        /// <returns></returns>
        public void MyToString()
        {
            Console.WriteLine(string.Format("Id:{0},workType:{1}", this.Id, this.workType));
        }

        /// <summary>
        /// 实体中的方法
        /// </summary>
        /// <returns></returns>
        public string ToString(string Msg)
        {
            var str = string.Format("Id:{0},workType:{1},msg:{2}", this.Id, this.workType, Msg);
            Console.WriteLine(str);
            return str;
        }
    }
}
