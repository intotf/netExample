using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlarmClock
{
    /// <summary>
    /// Xml 帮助类
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// 读取 xml 到指定对象
        /// 根节点名称 Root
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <param name="dataElement"></param>
        /// <returns></returns>
        private static IEnumerable<T> Read<T>(string file, string dataElement = "Data") where T : class, new()
        {
            if (!File.Exists(file))
            {
                Save<T>(null, file);
            }
            //将XML文件加载进来
            XDocument document = XDocument.Load(file);
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var item in root.Elements(dataElement))
            {
                var model = new T();
                foreach (var data in item.Elements())
                {
                    var property = properties.Where(p => p.Name.ToLower() == data.Name.ToString().ToLower()).FirstOrDefault();
                    if (property != null && property.Name != "CallBackAction")
                    {
                        property.SetValue(model, Convert.ChangeType(data.Value, property.PropertyType), null);
                    }
                }
                yield return model;
            }
        }


        /// <summary>
        /// 保存xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="file"></param>
        private static void Save<T>(IEnumerable<T> model, string file)
        {
            //获取根节点对象
            XDocument document = new XDocument();
            XElement root = new XElement("Root");
            if (model == null)
            {
                root.Save(file);
                return;
            }
            foreach (var data in model)
            {
                var properties = data.GetType().GetProperties();
                XElement xel = new XElement("Data");
                foreach (var item in properties)
                {
                    xel.SetElementValue(item.Name, item.GetValue(data));
                }
                root.Add(xel);
            }
            root.Save(file);
        }

        /// <summary>
        /// 根据 Xml 获取对象集合
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> GetList<T>() where T : class, new()
        {
            var xmlPath = string.Format("{0}.xml", typeof(T).Name);
            return XmlHelper.Read<T>(xmlPath);
        }

        /// <summary>
        /// 保存xml
        /// </summary>
        /// <returns></returns>
        public static void Save<T>(IEnumerable<T> model) where T : class, new()
        {
            var xmlPath = string.Format("{0}.xml", typeof(T).Name);
            XmlHelper.Save(model, xmlPath);
        }
    }
}
