using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.Config
{
    /// <summary>
    /// Mqtt Acl
    /// </summary>
    public class MqttAclConfigSection : ConfigurationSection
    {
        /// <summary>
        /// Auth Acl
        /// </summary>
        [ConfigurationProperty("AuthAcl")]
        public string AuthAcl
        {
            get
            {
                return (string)this["AuthAcl"];
            }
        }
    }
}
