using InterfaceLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLib
{
    /// <summary>
    /// 我是一个抽象类
    /// 1.抽象类跟普通类一样，但需要在前面加 abstract 修饰
    /// 2.virtual 可由基类重写实现
    /// 3.abstract 抽像方法只需要有方法名，由基类必需云实现
    /// 4.基类有用抽象类中的任意方法
    /// </summary>
    public abstract class WorkAbstract : IWork
    {
        /// <summary>
        /// 获取当前时间,只读型
        /// 不派生给基类
        /// </summary>
        public DateTime TimeNow
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// 派生类可以选择使用override 关键字而不是 new，将基类实现替换为它自己的实现
        /// virtual  虚方法  必须包含实现 但是可以被重载
        /// </summary>
        /// <returns></returns>
        public virtual DateTime GetTime()
        {

            return DateTime.Now;
        }

        /// <summary>
        /// 定义字段
        /// </summary>
        public Guid NewId;

        /// <summary>
        /// 工作者实体
        /// </summary>
        public abstract Worker Worker { get; set; }

        /// <summary>
        /// 抽象方法
        /// 由基类必需去实现
        /// </summary>
        public abstract void DoWork();

        /// <summary>
        /// 上班
        /// </summary>
        public virtual void OnWork()
        {
            Console.WriteLine("上班");
        }

        /// <summary>
        /// 异步上班
        /// </summary>
        /// <returns></returns>
        public async Task<bool> OnWorkAsync()
        {
            Console.WriteLine("OnWorkAsync 异步上班");
            await Task.Delay(1);
            return true;
        }
    }
}
