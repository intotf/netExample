using AbstractLib;
using AttributeLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLib
{

    /// <summary>
    /// 泛型类
    /// 1.where 增加约束, class 所有类,new() 带有无参数构造函数,
    ///         也可以是接口，特性等
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WorkGeneric<T> where T : Works
    {
        /// <summary>
        /// 开始工作
        /// </summary>
        /// <param name="t"></param>
        public void DoWork(T t)
        {
            t.DoWork();
        }

        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <returns></returns>
        public T GetDefault()
        {
            return default(T);
        }


        #region 泛型 协变，逆变
        /// <summary>
        /// 为了解决泛型父子类 关系的实例进行转换
        /// 协变，逆变;只能放在接口或者委托的泛型参数前面
        /// 协变：out 
        ///       只以做为返回值
        ///       左边是父，右边是子
        /// 逆变：in 
        ///       只可以做为参数值
        ///       左边是子，右边是父
        /// </summary>
        public void Test()
        {

            {
                parent parent1 = new parent();
                parent parent2 = new child(); //父类拥有子类的所有属性
                child child1 = new child();
            }

            {
                List<Worker> parentlist1 = new List<Worker>();
                //List<Worker> parentlist2 = new List<Worker>();   //两个list 泛型实例不存在集成关系

                // 为解决两个父子关系的实例采用协变进行；
                List<Worker> parentlist2 = new List<WorkBase>().Select(item => (Worker)item).ToList();

                ///协变 out 处理左侧是父，右侧是子
                IEnumerable<WorkBase> outList = new List<Worker>();
                IMyOut<WorkBase> outMyList = new MyOut<Worker>();

                //逆变 in 处理左侧是子，右侧是父
                IMyIn<Worker> inList = new MyIn<WorkBase>();


                //协变+逆变
                IMyInOut<Worker, WorkBase> myInOut = new MyInOut<WorkBase, Worker>();
                //协变
                IMyInOut<Worker, WorkBase> myInOut2 = new MyInOut<Worker, Worker>();
                //逆变
                IMyInOut<Worker, WorkBase> myInOut3 = new MyInOut<WorkBase, WorkBase>();
            }
        }
        #endregion

        #region 继承类 base 应用,实际是调用 child 的时候，是先来构造 parent
        /// <summary>
        /// 父类
        /// </summary>
        public class parent
        {
            public parent()
            {

            }

            public parent(string id)
            {
                this.id = id;
            }

            public string id { get; set; }
        }

        /// <summary>
        /// 子类
        /// </summary>
        public class child : parent
        {
            public child()
                : base("1234")
            {

            }
            public string name { get; set; }

        }
        #endregion

        #region 协逆变接口
        /// <summary>
        /// 协变接口 ,带 Out ,只输出
        /// </summary>
        /// <typeparam name="outT"></typeparam>
        public interface IMyOut<out outT>
        {
            outT Get();
        }

        public class MyOut<outT> : IMyOut<outT>
        {
            public outT Get()
            {
                return default(outT);
            }
        }

        /// <summary>
        /// 逆变接口,带 in 只输入不出
        /// </summary>
        /// <typeparam name="inT"></typeparam>
        public interface IMyIn<in inT>
        {
            void Get(inT t);
        }

        public class MyIn<inT> : IMyIn<inT>
        {
            public void Get(inT t)
            {
            }
        }

        /// <summary>
        /// 协变逆变一起使用
        /// </summary>
        /// <typeparam name="inT"></typeparam>
        /// <typeparam name="outT"></typeparam>
        public interface IMyInOut<in inT, out outT>
        {
            void Get(inT T);
            outT Set();
        }

        public class MyInOut<inT, outT> : IMyInOut<inT, outT>
        {
            void IMyInOut<inT, outT>.Get(inT T)
            {
            }

            outT IMyInOut<inT, outT>.Set()
            {
                return default(outT);
            }
        }
        #endregion
    }
}
