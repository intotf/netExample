using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.Config
{
    /// <summary>
    /// mqtt配置项
    /// </summary>
    public class MqttClientConfigSection : MqttAclConfigSection
    {
        /// <summary>
        /// 发布配置
        /// </summary>
        [ConfigurationProperty("Publish")]
        public MqttPubsub Publish
        {
            get
            {
                return (MqttPubsub)this["Publish"];
            }
        }

        /// <summary>
        /// 订阅配置
        /// </summary>
        [ConfigurationProperty("Subscribe")]
        public MqttPubsub Subscribe
        {
            get
            {
                return (MqttPubsub)this["Subscribe"];
            }
        }

        /// <summary>
        /// 发布配置
        /// </summary>
        [ConfigurationProperty("Nodes")]
        public MqttNodeCollection Nodes
        {
            get
            {
                return (MqttNodeCollection)this["Nodes"];
            }
        }
    }



    /// <summary>
    /// 发布订阅配置节点
    /// </summary>
    public class MqttPubsub : ConfigurationElement
    {
        /// <summary>
        /// Url地址
        /// </summary>
        [ConfigurationProperty("Address", DefaultValue = "http://localhost")]
        public string Address
        {
            get
            {
                return (string)base["Address"];
            }
            set
            {
                base["Address"] = value;
            }
        }

        /// <summary>
        /// 账号
        /// </summary>
        [ConfigurationProperty("Account")]
        public string Account
        {
            get
            {
                return (string)base["Account"];
            }
            set
            {
                base["Account"] = value;
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        [ConfigurationProperty("Password")]
        public string Password
        {
            get
            {
                return (string)base["Password"];
            }
            set
            {
                base["Password"] = value;
            }
        }
    }

    /// <summary>
    /// Mqtt节点
    /// </summary>
    public class MqttNode : ConfigurationElement
    {
        /// <summary>
        /// ip
        /// </summary>
        [ConfigurationProperty("IP")]
        public string IP
        {
            get
            {
                return (string)base["IP"];
            }
        }

        /// <summary>
        /// 端口
        /// </summary>
        [ConfigurationProperty("Port")]
        public int Port
        {
            get
            {
                return (int)base["Port"];
            }
        }
    }

    /// <summary>
    /// Mqtt节点集合
    /// </summary>
    public class MqttNodeCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MqttNode();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var ele = element as MqttNode;
            return ele.IP;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "Node";
            }
        }
    }
}
