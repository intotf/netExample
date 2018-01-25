using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericLib
{
    /// <summary>
    /// 泛型委托学习
    /// </summary>
    public class WorkDelegate
    {
        /// <summary>
        /// 自定义 声名一个无返回的委托
        /// </summary>
        public delegate void modelDelegate(Worker model);

        public void modelDeleegateFun(Worker model)
        {
            Console.WriteLine("通过委托返回对象的名称：{0}", model.Name);
        }

        /// <summary>
        /// 初始化委托
        /// </summary>
        public void GetDelegate()
        {
            modelDelegate dele = this.modelDeleegateFun;
            dele.Invoke(new Worker("张三"));
        }

        /// <summary>
        /// 泛型委托,对T 约束必需继成 BaseCarModel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="f"></param>
        /// <param name="t"></param>
        /// <param name="Model"></param>
        public void GenericFun<T>(Func<T> f, T Model) where T : Worker
        {
            Type type = Model.GetType();
            var propertys = type.GetProperties();
            Console.WriteLine("循环显示对象的所有属性及对应的类型");
            foreach (var item in propertys)
            {
                Console.WriteLine("对象名称:{0},类型为：{1},值为：{2}", item.Name, item.GetType(), item.GetValue(Model, null));
            }
        }

        /// <summary>
        /// 表达式树
        /// 语法树，或是说一种数据结构
        /// </summary>
        public void ExpressionsFunc()
        {
            //定义一个委托
            Func<int, int, int> func = (m, n) => m * n;
            //表达式树
            Expression<Func<int, int, int>> expFunc = (m, n) => m * n;

            var isReulst1 = func.Invoke(2, 3);
            var isReulst2 = expFunc.Compile().Invoke(2, 4);
        }
    }
}
