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
        /// 测试数据
        /// </summary>
        /// <param name="num">设备机身号</param>
        /// <param name="data">数据</pm>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<string>> Sys_TestDataAsync(string num, string data)
        {
            var api = Api.Sys_TestData;
            var device = new Device(num);
            var body = new TimeoutDataSetting { Timeout = 5, Data = data };
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, body);
            return message.Cast<string>();
        }

        /// <summary>
        /// 要求上传日志指令
        /// </summary>
        /// <param name="num">设备机身号</param>
        /// <param name="data">控制内容</param>
        /// <returns></returns>
        public static async Task Sys_UploadLogAsync(string num, UploadLogSetting data)
        {
            var api = Api.Sys_UploadLog;
            var device = new Device(num);
            var timeout = TimeoutRequest.Default;
            await EmqttdClient.PostAsync(device.SubDevice, api, data);
        }

        /// <summary>
        /// 设备系统控制
        /// </summary>
        /// <param name="num">设备机身号</param>
        /// <param name="data">控制内容</param> 
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> Sys_ControlAsync(string num, SysCtrlSetting data)
        {
            var api = Api.Sys_Control;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }       
    }
}
