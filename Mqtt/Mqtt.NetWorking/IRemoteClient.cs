using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.NetWorking
{
    /// <summary>
    /// 定义mqtt远程客户端的接口
    /// </summary>
    public interface IRemoteClient
    {
        /// <summary>
        /// 获取所有订阅主题
        /// </summary>
        /// <returns></returns>
        IEnumerable<Topic> GetAllSubTopics();

        /// <summary>
        /// 获取所有发布主题
        /// </summary>
        /// <returns></returns>
        IEnumerable<Topic> GetAllPubTopics();
    }
}
