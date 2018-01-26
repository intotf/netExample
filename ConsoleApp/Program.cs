using AbstractLib;
using AttributeLib;
using ModelLib;
using Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GenericLib;
using ExpressionLib;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        //构造一个工作者
        private static Worker worker = new Worker("张三") { Sex = "男", Age = 18, workType = WorkType.Management, Id = Guid.NewGuid().ToString().Replace("-", "") };

        private static WorkTwo work = new WorkTwo(worker);

        /// <summary>
        /// 程序开始
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //重写 控制台输出
            Console.SetOut(MyWriter.Out);

            Console.WriteLine("学习开始..................................");
            #region 基础方法调用
            {
                //Console.WriteLine("基础方法调用-----------------------------------");
                //var work = new WorkTwo(worker);
                //RunTask(work);
                //work.DoWork();

                //for (int i = 0; i < 10; i++)
                //{
                //    Console.WriteLine("循环第{0}次尝试创建对象 WorkLook", i);
                //    var modelLook = WorkLook.CreateWorkLook();
                //}
                //Console.WriteLine("基础方法调用-----------------------------------");
            }
            #endregion

            #region 反射,详细使用见 Reflection
            Console.WriteLine("反射学习-----------------------------------");
            //var WorkRef = new WorkReflection();
            //var works = WorkRef.GetWorksByAttribute(worker).ToList();
            //foreach (var item in works)
            //{
            //    item.DoWork();
            //}

            ////实体反射
            var modelRef = new ModelReflection();
            var method = modelRef.GetMethods(worker, "ToString");

            var parameters = new Dictionary<string, object>();
            parameters.Add("Msg", "中华人民共和国");   //Key 注意大小写
            modelRef.MethodInvoke(method, parameters);
            modelRef.GetPropertieValue(worker, item => item.Id);
            Console.WriteLine("反射学习-----------------------------------");
            #endregion

            #region 泛型学习
            //Console.WriteLine("泛型学习-----------------------------------");
            //var generic = new WorkGeneric<WorkTwo>();
            //generic.DoWork(work);
            //var workDefault = generic.GetDefault();
            //var s = new WorkDelegate();
            //s.ExpressionsFunc();

            //Console.WriteLine("泛型学习-----------------------------------");
            #endregion

            #region 并行操作
            //Console.WriteLine("并行测试-------------------------------------------------");
            //WorkParallel.ParallelInvokeMethod();
            //WorkParallel.ParallelTask();
            //Console.WriteLine("并行测试-------------------------------------------------");
            #endregion

            #region 多行程 Task
            //Console.WriteLine("多行程学习-----------------------------------");
            //WorksTask.TaskRun();
            //Console.WriteLine("多行程学习-----------------------------------");
            #endregion

            #region 表达式树

            //var where = Where.True<Worker>().And(it => it.Name.Contains("aa"));

            #endregion

            #region 线程安全缓存
            CacheHelper<Worker>.Add(worker.Id, worker);
            var woreks = CacheHelper<Worker>.GetAllCaches();
            CacheHelper<string>.TestRun();
            #endregion
            Console.ReadKey();
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="model"></param>
        private static async void RunTask(Works model)
        {
            var RunState = await model.OnWorkAsync();
            Console.WriteLine("RunTask 运行结果：{0}", RunState);
        }

    }
}
