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

namespace ConsoleApp
{
    class Program
    {
        //构造一个工作者
        private static Worker worker = new Worker() { Name = "张三", Sex = "男", Age = 18, workType = WorkType.Management, Id = Guid.NewGuid().ToString().Replace("-", "") };

        /// <summary>
        /// 程序开始
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //重写 控制台输出
            Console.SetOut(MyWriter.Out);

            #region 基础方法调用
            {
                //var work = new WorkTwo(worker);
                //RunTask(work);
                //work.DoWork();
            }
            #endregion

            #region 反射,详细使用见 Reflection
            //var WorkRef = new WorkReflection();
            //var works = WorkRef.GetWorksByAttribute(worker).ToList();
            //foreach (var item in works)
            //{
            //    item.DoWork();
            //}

            ////实体反射
            //var modelRef = new ModelReflection();
            //var method = modelRef.GetMethods(worker, "ToString");

            //var parameters = new Dictionary<string, object>();
            //parameters.Add("Msg", "中华人民共和国");   //Key 注意大小写
            //modelRef.MethodInvoke(method, parameters);
            //modelRef.GetPropertieValue(worker, item => item.Id);
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
