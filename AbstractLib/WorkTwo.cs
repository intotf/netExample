using AttributeLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLib
{
    /// <summary>
    /// 工作2
    /// </summary>
    [Work(2, "002")]
    public class WorkTwo : Works
    {
        /// <summary>
        /// 构造函数,base(model) 构造父类
        /// 继承类 Works 应用,实际是调用 WorkTwo 的时候，是先来构造 Works
        /// </summary>
        /// <param name="model"></param>
        public WorkTwo(Worker model)
            : base(model)
        {

        }

        /// <summary>
        /// 重写父类方法
        /// </summary>
        public override void DoWork()
        {
            base.DoWork();
        }
    }
}
