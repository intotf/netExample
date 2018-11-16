using HDP.Networking.Bodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// MqttApi客户端
    /// </summary>
    public static partial class MqttApiClient
    {
        /// <summary>
        /// 投递自定义数据到客户端
        /// 不等待设备的回执
        /// </summary>
        /// <param name="id">客户端id</param>
        /// <param name="data">数据内容</param>
        /// <returns></returns>
        public static async Task Push_CustomDataPostAsync(string id, string data)
        {
            var api = Api.Push_CustomData_Post;
            var client = new PushClient(id);
            await EmqttdClient.PostAsync(client.SubPushClient, api, data);
        }

        /// <summary>
        /// 发送自定义数据到客户端
        /// 并等待设备的回执
        /// </summary>
        /// <param name="id">客户端id</param>
        /// <param name="data">数据内容</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>       
        public static async Task<Message> Push_CustomDataSendAsync(string id, TimeoutDataSetting data)
        {
            var api = Api.Push_CustomData_Send;
            var client = new PushClient(id);
            return await EmqttdClient.SendAsync(client.SubPushClient, api, data);
        }
    }
}
