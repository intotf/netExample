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
    /// 室内机下的红外主机
    /// </summary>
    public static partial class MqttApiClient
    {
        /// <summary>
        /// 获取红外空调按键学习状态
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">空调控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMInfAirKeyState[]>> CM_GetInfAirKeysAsync(string num, CMCtrlRequest data)
        {
            var api = Api.CM_GetInfAirKeys;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMInfAirKeyState[]>();
        }

        /// <summary>
        /// 红外空调按键学习
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">空调控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_LearnInfAirKeyAsync(string num, CMInfAirKeyCtrl data)
        {
            var api = Api.CM_LearnInfAirKey;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 红外空调按键控制
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">空调控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetInfAirAsync(string num, CMInfAirKeyCtrl data)
        {
            var api = Api.CM_SetInfAir;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 获取红外电视按键学习状态
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">电视控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMInfTvKeyState[]>> CM_GetInfTvKeysAsync(string num, CMCtrlRequest data)
        {
            var api = Api.CM_GetInfTvKeys;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMInfTvKeyState[]>();
        }

        /// <summary>
        /// 红外电视按键学习
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">电视控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_LearnInfTvKeyAsync(string num, CMInfTvKeyCtrl data)
        {
            var api = Api.CM_LearnInfTvKey;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 红外电视按键控制
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">电视控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetInfTvAsync(string num, CMInfTvKeyCtrl data)
        {
            var api = Api.CM_SetInfTv;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 获取红外机顶盒按键学习状态
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">机顶盒控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMInfTopboxKeyState[]>> CM_GetInfTopboxKeysAsync(string num, CMCtrlRequest data)
        {
            var api = Api.CM_GetInfTopboxKeys;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMInfTopboxKeyState[]>();
        }

        /// <summary>
        /// 红外机顶盒按键学习
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">机顶盒控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_LearnInfTopboxKeyAsync(string num, CMInfTopboxKeyCtrl data)
        {
            var api = Api.CM_LearnInfTopboxKey;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 红外机顶盒按键控制
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">机顶盒控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetInfTopboxAsync(string num, CMInfTopboxKeyCtrl data)
        {
            var api = Api.CM_SetInfTopbox;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 获取红外DVD按键学习状态
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">DVD控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMInfDvdKeyState[]>> CM_GetInfDvdKeysAsync(string num, CMCtrlRequest data)
        {
            var api = Api.CM_GetInfDvdKeys;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMInfDvdKeyState[]>();
        }

        /// <summary>
        /// 红外DVD按键学习
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">DVD控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_LearnInfDvdKeyAsync(string num, CMInfDvdKeyCtrl data)
        {
            var api = Api.CM_LearnInfDvdKey;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 红外DVD按键控制
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">DVD控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetInfDvdAsync(string num, CMInfDvdKeyCtrl data)
        {
            var api = Api.CM_SetInfDvd;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 获取红外 [自定义遥控器1] 按键学习状态
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">[自定义遥控器1] 控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMInfTeleOneKeyState[]>> CM_GetInfTeleOneKeysAsync(string num, CMCtrlRequest data)
        {
            var api = Api.CM_GetInfTeleOneKeys;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMInfTeleOneKeyState[]>();
        }

        /// <summary>
        /// 红外 [自定义遥控器1] 按键学习
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">[自定义遥控器1] 控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_LearnInfTeleOneKeyAsync(string num, CMInfTeleOneKeyCtrl data)
        {
            var api = Api.CM_LearnInfTeleOneKey;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 红外 [自定义遥控器1] 按键控制
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">[自定义遥控器1] 控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetInfTeleOneAsync(string num, CMInfTeleOneKeyCtrl data)
        {
            var api = Api.CM_SetInfTeleOne;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 获取红外 [自定义遥控器2] 按键学习状态
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">[自定义遥控器2] 控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMInfTeleTwoKeyState[]>> CM_GetInfTeleTwoKeysAsync(string num, CMCtrlRequest data)
        {
            var api = Api.CM_GetInfTeleTwoKeys;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMInfTeleTwoKeyState[]>();
        }

        /// <summary>
        /// 红外 [自定义遥控器2] 按键学习
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">[自定义遥控器2] 控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_LearnInfTeleTwoKeyAsync(string num, CMInfTeleTwoKeyCtrl data)
        {
            var api = Api.CM_LearnInfTeleTwoKey;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 红外 [自定义遥控器2] 按键控制
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">[自定义遥控器2] 控制数据实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetInfTeleTwoAsync(string num, CMInfTeleTwoKeyCtrl data)
        {
            var api = Api.CM_SetInfTeleTwo;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }
    }
}
