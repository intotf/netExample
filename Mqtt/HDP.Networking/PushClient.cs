using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// 表示推送客户端
    /// </summary>
    public class PushClient : IRemoteClient
    {
        /// <summary>
        /// 获取客户端编号
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// 客户端信息
        /// </summary>
        /// <param name="id">客户端编号</param>
        public PushClient(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// 获取订阅的客户端主题
        /// </summary>
        public SingleTopic SubPushClient
        {
            get
            {
                return new SingleTopic("sub/pushclients/{0}", this.Id);
            }
        }

        /// <summary>
        /// 获取发布的主题
        /// </summary>
        public SingleTopic PubPushClient
        {
            get
            {
                return new SingleTopic("pub/pushclients/{0}", this.Id);
            }
        }

        /// <summary>
        /// 获取所有订阅主题
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Topic> GetAllSubTopics()
        {
            yield return this.SubPushClient;
        }

        /// <summary>
        /// 获取所有发布主题
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Topic> GetAllPubTopics()
        {
            yield return this.PubPushClient;
        }
    }
}
