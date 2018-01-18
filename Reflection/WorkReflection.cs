using AbstractLib;
using AttributeLib;
using InterfaceLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    /// <summary>
    /// 常用反射
    /// </summary>
    public class WorkReflection
    {
        /// <summary>
        /// 获WorkAbstract 抽象类取所有继承者
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Works> GetWorksByAbstract(Worker model)
        {
            var works = AppDomain.CurrentDomain.GetAssemblies().SelectMany(item => item.GetTypes())
               .Where(item => item.IsAbstract == false && item.IsValueType == false)
               .Select(item => Activator.CreateInstance(item, model) as Works);
            return works;
        }

        /// <summary>
        /// 获WorkAbstract 抽象类取所有继承者
        /// 通过特性 WorkAttribute.Level 进行排序
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Works> GetWorksByAbstractSort(Worker model)
        {
            var works = this.GetWorksByAbstract(model);
            var result = works.Select(item => new
                            {
                                m = item,
                                a = item.GetType().GetCustomAttributes<WorkAttribute>().FirstOrDefault()
                            })
                            .Where(item => item.a != null)
                            .OrderBy(item => item.a.Level)
                            .Select(item => item.m);
            return result;
        }

        /// <summary>
        /// 获取实现IWork 接口的类
        /// 并根据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Works> GetWorksByIWork(Worker model)
        {
            var works = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(item => item.GetTypes())
                        .Where(item => item.GetInterfaces().Contains(typeof(IWork)) && item.IsAbstract == false)
                        .Select(item => Activator.CreateInstance(item, model) as Works)
                        .ToArray();
            return works;
        }

        /// <summary>
        /// 获取实现IWork 接口的类
        /// 通过特性 WorkAttribute.Level 进行排序
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Works> GetWorksByIWorkSort(Worker model)
        {
            
            var works = this.GetWorksByIWork(model);
            var result = works.Select(item => new
                            {
                                m = item,
                                t = item.GetType().GetCustomAttributes<WorkAttribute>().FirstOrDefault()
                            })
                            .Where(item => item.t != null)
                            .OrderBy(item => item.t.Level)
                            .Select(item => item.m);
            return result;
        }

        /// <summary>
        /// 获取所有设定了 WorkAttribute 特性的 Works
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Works> GetWorksByAttribute(Worker model)
        {
            var works = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(item => item.GetTypes())
                        .Where(item => item.IsDefined(typeof(WorkAttribute), true) && item.IsAbstract == false)
                        .Select(item => Activator.CreateInstance(item, model) as Works);
            return works;
        }
    }
}
