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
    /// 工作一
    /// </summary>
    [Work(1, "001")]
    public class WorkOne : Works
    {
        /// <summary>
        /// 继承类 Works 应用,实际是调用 WorkOne 的时候，是先来构造 Works
        /// </summary>
        /// <param name="model"></param>
        public WorkOne(Worker model)
            : base(model)
        {

        }

        /// <summary>
        /// 重写父类方法
        /// </summary>
        public override void DoWork()
        {
            Console.WriteLine("重写父类 DoWork 方法 当前工作：{0}", this.GetType().Name);
            Console.WriteLine("我叫{0},我的职位{1},我的工作描叙{2}.",
                                base.Worker.Name,
                                this.Worker.workType.GetDisplayName(),
                                this.Worker.workType.GetDisplayDescription());
        }
    }
}
