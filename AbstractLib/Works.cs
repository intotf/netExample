using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeLib;
using ModelLib;

namespace AbstractLib
{
    /// <summary>
    /// 工作父类
    /// 1.继承了一个抽象类,我可以重写带有 virtual 的修饰
    /// 2.我需要实现带 abstract 的抽象方法
    /// 3. this.TimeNow 表式当前类的TimeNow。如没有默认是父类的 TimeNow
    /// 4. base.TimeNow 表式父类的 TimeNow
    /// </summary>
    [Work(0, "999")]
    public class Works : WorkAbstract
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Works(Worker model)
        {
            this.NewId = Guid.NewGuid();
            this.Worker = model;
        }

        /// <summary>
        /// 工作者
        /// </summary>
        public override Worker Worker { get; set; }

        /// <summary>
        /// 父类方法重写
        /// </summary>
        public override void DoWork()
        {
            Console.WriteLine("我叫{0},我的职位{1},开始工作 {2}.", this.Worker.Name, this.Worker.workType.GetDisplayName(), this.GetType().Name);
        }

        /// <summary>
        /// 密封方法,基类可以继承,但不能重写
        /// </summary>
        public sealed override void OnWork()
        {
            Console.WriteLine("我是一个密封方法,基类不可重写");
        }

        /// <summary>
        /// 重写父类方法
        /// </summary>
        /// <returns></returns>
        public override DateTime GetTime()
        {
            //重写
            return DateTime.Now;
        }

    }
}
