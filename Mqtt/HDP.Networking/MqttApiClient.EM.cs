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
        /// 投递自定义数据到门口机
        /// 不等待设备的回执
        /// </summary>
        /// <param name="num">设备机身号</param>
        /// <param name="data">数据内容</param>
        /// <returns></returns>
        public static async Task EM_CustomDataPostAsync(string num, string data)
        {
            var api = Api.EM_CustomData_Post;
            var device = new Device(num);
            await EmqttdClient.PostAsync(device.SubDevice, api, data);
        }

        /// <summary>
        /// 发送自定义数据到门口机
        /// 并等待设备的回执
        /// </summary>
        /// <param name="num">设备机身号</param>
        /// <param name="data">数据内容</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>       
        public static async Task<Message> EM_CustomDataSendAsync(string num, TimeoutDataSetting data)
        {
            var api = Api.EM_CustomData_Send;
            var device = new Device(num);
            return await EmqttdClient.SendAsync(device.SubDevice, api, data);
        }


        /// <summary>
        /// 门口机开锁
        /// </summary>
        /// <param name="num">门口机机身号</param>
        /// <param name="data">数据</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> EM_UnlockAsync(string num, TimeoutDataSetting data)
        {
            var api = Api.EM_Unlock;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }
         
    }
}
