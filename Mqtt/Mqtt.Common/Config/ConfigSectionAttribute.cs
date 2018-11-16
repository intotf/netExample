using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.Config
{
    /// <summary>
    /// 配置节点特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ConfigSectionAttribute : Attribute
    {
        /// <summary>
        /// 获取配置名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取配置节点
        /// </summary>
        public object Section { get; private set; }

        /// <summary>
        /// 配置特性
        /// </summary>
        /// <param name="name">配置名称</param>
        public ConfigSectionAttribute(string name)
        {
            this.Name = name;
            this.Section = ConfigurationManager.GetSection(name);
        }

        /// <summary>
        /// 获取类配置的节点信息
        /// </summary>
        /// <typeparam name="TConfig">配置节点类型</typeparam>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static TConfig GetConfigSection<TConfig>(Type type) where TConfig : ConfigurationSection
        {
            var attribute = Attribute.GetCustomAttribute(type, typeof(ConfigSectionAttribute)) as ConfigSectionAttribute;
            return attribute.Section as TConfig;
        }
    }
}
