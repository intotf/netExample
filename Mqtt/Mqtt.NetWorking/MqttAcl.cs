using Mqtt.Common.Utility;
using Mqtt.Config;
using Mqtt.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.NetWorking
{
    /// <summary>
    /// Mqtt Acl
    /// </summary>
    [ConfigSection("Mqtt")]
    public static class MqttAcl
    {
        /// <summary>
        /// 账号配置
        /// </summary>
        private static readonly MqttAclConfigSection config = ConfigSectionAttribute.GetConfigSection<MqttAclConfigSection>(typeof(EmqttdClient));

        /// <summary>
        /// 获取redis连接管理
        /// </summary>
        private static readonly Multiplexer redisClient = new Multiplexer(config.AuthAcl);

        /// <summary>
        /// 授权客户端
        /// </summary>
        /// <param name="client">设备客户端</param>
        /// <param name="num">机身号</param>
        /// <param name="password">明文密码</param>
        /// <returns></returns>
        public static async Task AuthAclAsync(IRemoteClient client, string num, string password)
        {
            // HSET mqtt_user:<username> is_superuser 0
            // HSET mqtt_user:<username> password "passwd"

            var db = redisClient.GetMultiplexer().GetDatabase();

            var authKey = string.Format("mqtt_user:{0}", num);
            var superEntry = new HashEntry("is_superuser", 0);
            var passwordEntry = new HashEntry("password", Encryption.GetMD5(password).ToLower());

            await db.KeyDeleteAsync(authKey);
            await db.HashSetAsync(authKey, new[] { superEntry, passwordEntry });


            // 1: subscribe, 2: publish, 3: pubsub
            // HSET mqtt_acl:<username> topic1 1
            // HSET mqtt_acl:<username> topic2 2
            // HSET mqtt_acl:<username> topic3 3

            var subTopics = client.GetAllSubTopics();
            var pubTopics = client.GetAllPubTopics();

            var aclKey = string.Format("mqtt_acl:{0}", num);
            var subEntries = subTopics.Select(topic => new HashEntry(topic.Value, 1));
            var pubEntries = pubTopics.Select(topic => new HashEntry(topic.Value, 2));
            var entries = subEntries.Concat(pubEntries).ToArray();

            await db.KeyDeleteAsync(aclKey);
            await db.HashSetAsync(aclKey, entries);
        }

        /// <summary>
        /// 授权管理员
        /// </summary>
        /// <param name="adminAccount">管理员账号</param>
        /// <param name="password">明文密码</param>
        public static void AuthAcl(string adminAccount, string password)
        {
            // HSET mqtt_user:<username> is_superuser 1
            // HSET mqtt_user:<username> password "passwd"

            var db = redisClient.GetMultiplexer().GetDatabase();

            var authKey = string.Format("mqtt_user:{0}", adminAccount);
            var superEntry = new HashEntry("is_superuser", 1);
            var passwordEntry = new HashEntry("password", Encryption.GetMD5(password).ToLower());

            db.HashSet(authKey, new[] { superEntry, passwordEntry });

            var aclKey = string.Format("mqtt_acl:{0}", adminAccount);
            var topic = "#";
            db.HashSet(aclKey, topic, 3);
        }

        /// <summary>
        /// 授权管理员
        /// </summary>
        /// <param name="adminAccount">管理员账号</param>
        /// <param name="password">明文密码</param>
        /// <returns></returns>
        public static async Task AuthAclAsync(string adminAccount, string password)
        {
            // HSET mqtt_user:<username> is_superuser 1
            // HSET mqtt_user:<username> password "passwd"

            var db = redisClient.GetMultiplexer().GetDatabase();

            var authKey = string.Format("mqtt_user:{0}", adminAccount);
            var superEntry = new HashEntry("is_superuser", 1);
            var passwordEntry = new HashEntry("password", Encryption.GetMD5(password).ToLower());

            await db.HashSetAsync(authKey, new[] { superEntry, passwordEntry });

            var aclKey = string.Format("mqtt_acl:{0}", adminAccount);
            var topic = "#";
            await db.HashSetAsync(aclKey, topic, 3);
        }

        /// <summary>
        /// 取消授权
        /// </summary>
        /// <param name="num">机身号</param>
        /// <returns></returns>
        public static async Task UnAuthAclAsync(string num)
        {
            var keyAcl = string.Format("mqtt_acl:{0}", num);
            var keyAuth = string.Format("mqtt_user:{0}", num);
            var db = redisClient.GetMultiplexer().GetDatabase();
            await db.KeyDeleteAsync(keyAcl);
            await db.KeyDeleteAsync(keyAuth);
        }
    }
}
