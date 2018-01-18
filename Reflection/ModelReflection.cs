using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    /// <summary>
    /// 实体反射
    /// </summary>
    public class ModelReflection
    {
        /// <summary>
        /// 获取任意对象的属性信息(名称、类型 、值)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        public void GetProperties<T>(T model) where T : class,new()
        {
            var properties = model.GetType().GetProperties();
            Console.WriteLine("{0} 对象有 {1} 个属性如下：", model.GetType().Name, properties.Count());
            foreach (var item in properties)
            {
                Console.WriteLine("属性名称：{0} 属性类型：{1} 当前值：{2}", item.Name, item.PropertyType, item.GetValue(model, null));
            }
        }

        /// <summary>
        /// 方法比较器
        /// 过滤Object 基类中的方法，只保留自身写的方法
        /// </summary>
        private class MethodCom : IEqualityComparer<MethodInfo>
        {
            public bool Equals(MethodInfo x, MethodInfo y)
            {
                return true;
            }

            /// <summary>
            /// 按位“异或”运算符 (^)
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public int GetHashCode(MethodInfo obj)
            {
                return obj.DeclaringType.GetHashCode() ^ obj.Name.GetHashCode();
            }
        }

        /// <summary>
        /// 执行类中指定方法
        /// 1. IsSpecialName = 是否具有特殊名称，则为 true；否则为 false。
        /// 2. IsSecurityCritical = 该值指示当前方法或构造函数在当前信任级别上是安全关键的还是安全可靠关键的
        /// 3. IsSecuritySafeCritical = 如果方法或构造函数在当前信任级别上是安全可靠关键的，则为 true；如果它是安全关键的或透明的，则为 false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">指定的实体</param>
        /// <param name="MethodName">执行方法名</param>
        public MethodInfo GetMethods<T>(T model, string MethodName = "MyToString") where T : class,new()
        {
            var methods = model.GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.Instance).
                Where(item => item.IsSpecialName == false)
                .Except(typeof(object).GetMethods(), new MethodCom());

            //获取当前自定义的方法
            //var methods = model.GetType().GetMethods().Where(item => item.IsSpecialName == false && item.IsSecurityCritical && item.IsSecuritySafeCritical == false);
            var method = methods.FirstOrDefault(item => item.Name == MethodName);
            if (method.IsNullOrEmpty())
            {
                Console.WriteLine("{0} 中没有该方法.", model.GetType().Name);
            }
            return method;
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="method">方法信息</param>
        /// <param name="parameters">参数信息</param>
        public void MethodInvoke(MethodInfo method, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            if (method == null)
            {
                Console.WriteLine("方法信息为 null,执行失败.");
                return;
            }
            Console.WriteLine("{0} 方法执行如下：", method.Name);
            ParameterInfo[] paramsInfo = method.GetParameters();    //得到指定方法的参数列表 
            var obj = Activator.CreateInstance(method.DeclaringType);
            ////2.方法需要传入的参数
            object[] parame = new object[paramsInfo.Length];
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                var pType = paramsInfo[i].ParameterType;
                var KeyValue = parameters.Where(item => item.Key.Contains(paramsInfo[i].Name)).FirstOrDefault();
                object value = paramsInfo[i].DefaultValue;
                if (!KeyValue.IsNullOrEmpty())
                {
                    value = KeyValue.Value;
                }
                parame[i] = Convert.ChangeType(value, pType);
            }
            method.Invoke(obj, parame);
            Console.WriteLine("------------------------------------------------");
        }

        /// <summary>
        /// 获取对象指定属性的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="FieldName"></param>
        public void GetPropertieValue<T>(T model, string FieldName)
        {
            var propertie = model.GetType().GetProperties().Where(item => item.Name == FieldName).FirstOrDefault();
            if (propertie == null)
            {
                Console.WriteLine("{0} 没有 {1} 属性", model.GetType().Name, FieldName);
                return;
            }
            Console.WriteLine("{0} 对象 {1} 的值为：{2}", model.GetType().Name, FieldName, propertie.GetValue(model, null));
        }

        /// <summary>
        /// 获取对象指定属性的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">实体</param>
        /// <param name="field">字段名</param>
        public void GetPropertieValue<T, TKey>(T model, Func<T, TKey> field)
        {
            var value = field(model);
            Console.WriteLine("{0} 指定属性值为：{1}", model.GetType().Name, value);
        }
    }
}
