using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// 表示设备客户端信息
    /// </summary>
    public class Device : IRemoteClient
    {
        /// <summary>
        /// 获取机身号
        /// </summary>
        public string Num { get; private set; }

        /// <summary>
        /// 获取对应的开发者应用Id
        /// </summary>
        public string APP_ID { get; private set; }

        /// <summary>
        /// 获取设备类型简写
        /// </summary>
        public string ShortType { get; private set; }


        /// <summary>
        /// 获取订阅的根主题
        /// </summary>
        public Topic Sub
        {
            get
            {
                return new Topic("sub");
            }
        }

        /// <summary>
        /// 获取订阅的设备主题
        /// </summary>
        public SingleTopic SubDevice
        {
            get
            {
                return new SingleTopic("sub/devices/{0}", this.Num);
            }
        }

        /// <summary>
        /// 获取订阅的类别主题
        /// </summary>
        public Topic SubShortType
        {
            get
            {
                return new Topic("sub/shorttypes/{0}", this.ShortType.ToString());
            }
        }

        /// <summary>
        /// 获取订阅的应用主题
        /// </summary>
        public Topic SubApplication
        {
            get
            {
                return new Topic("sub/apps/{0}", this.APP_ID);
            }
        }

        /// <summary>
        /// 获取订阅的应用下设备类别主题
        /// </summary>
        public Topic SubApplicationShortType
        {
            get
            {
                return new Topic("sub/apps/{0}/shorttypes/{1}", this.APP_ID, this.ShortType.ToString());
            }
        }

        /// <summary>
        /// 获取发布的设备主题
        /// </summary>
        public SingleTopic PubDevice
        {
            get
            {
                return new SingleTopic("pub/devices/{0}", this.Num);
            }
        }

        /// <summary>
        /// 设备客户端信息
        /// </summary>
        /// <param name="num">机身号</param>
        public Device(string num)
        {
            this.Num = num;
        }


        /// <summary>
        /// 设备客户端信息
        /// </summary>
        /// <param name="num">机身号</param>
        /// <param name="app_Id">应用id</param>
        /// <param name="shortType">设备类别</param> 
        public Device(string num, string app_Id, string shortType)
        {
            this.Num = num;
            this.APP_ID = app_Id;
            this.ShortType = shortType;
        }

        /// <summary>
        /// 获取所有订阅主题
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Topic> GetAllSubTopics()
        {
            yield return this.Sub;
            yield return this.SubDevice;
            yield return this.SubShortType;
            yield return this.SubApplication;
            yield return this.SubApplicationShortType;
        }

        /// <summary>
        /// 获取所有发布主题
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Topic> GetAllPubTopics()
        {
            yield return this.PubDevice;
        }
    }
}
