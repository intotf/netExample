using HDP.Model.Dtos;
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
        /// 获取中控机的情景模式列表
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMSceneInfo[]>> CM_GetSceneListAsync(string num)
        {
            var api = Api.CM_GetSceneList;
            var data = TimeoutRequest.Default;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMSceneInfo[]>();
        }

        /// <summary>
        /// 设置中控机的情景模式
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">数据</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetSceneAsync(string num, CMSceneSetting data)
        {
            var api = Api.CM_SetScene;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }


        /// <summary>
        /// 获取中控机的设备列表
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMDeivceData>> CM_GetDeviceListAsync(string num)
        {
            var api = Api.CM_GetDeviceList;
            var data = TimeoutRequest.Default;
            var device = new Device(num);

            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMDeivceData>();
        }


        ///// <summary>
        ///// 智能空调控制
        ///// </summary>
        ///// <param name="num">中控机机身号</param>
        ///// <param name="data">CMAirBody 空调控制实体</param>
        ///// <exception cref="TimeoutException"></exception>
        ///// <returns></returns>
        //public static async Task<Message<bool>> CM_SetAirAsync(string num, CMAirSetting data)
        //{
        //    var api = Api.CM_SetAir;
        //    var device = new Device(num);
        //    var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
        //    return message.Cast<bool>();
        //}

        /// <summary>
        /// 恒亦明LED控制器
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMLedBody 控制实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetLedAsync(string num, CMLedSetting data)
        {
            var api = Api.CM_SetLed;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        ///// <summary>
        ///// 设备智能电视控制
        ///// </summary>
        ///// <param name="num">中控机机身号</param>
        ///// <param name="data">CMAirOtherBody 空调控制实体</param>
        ///// <exception cref="TimeoutException"></exception>
        ///// <returns></returns>
        //public static async Task<Message<bool>> CM_SetTVAsync(string num, CMTVSetting data)
        //{
        //    var api = Api.CM_SetTV;
        //    var device = new Device(num);
        //    var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
        //    return message.Cast<bool>();
        //}

        ///// <summary>
        ///// 设备智能机顶盒控制
        ///// </summary>
        ///// <param name="num">中控机机身号</param>
        ///// <param name="data">CMTopboxBody 机顶盒实体</param>
        ///// <exception cref="TimeoutException"></exception>
        ///// <returns></returns>
        //public static async Task<Message<bool>> CM_SetTopboxAsync(string num, CMTopboxSetting data)
        //{
        //    var api = Api.CM_SetTopbox;
        //    var device = new Device(num);
        //    var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
        //    return message.Cast<bool>();
        //}

        ///// <summary>
        ///// 设备智能DVD控制
        ///// </summary>
        ///// <param name="num">中控机机身号</param>
        ///// <param name="data">CMDvdBody DVD实体</param>
        ///// <exception cref="TimeoutException"></exception>
        ///// <returns></returns>
        //public static async Task<Message<bool>> CM_SetDvdAsync(string num, CMDvdSetting data)
        //{
        //    var api = Api.CM_SetDvd;
        //    var device = new Device(num);
        //    var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
        //    return message.Cast<bool>();
        //}

        ///// <summary>
        ///// 自定义智能设备 1
        ///// </summary>
        ///// <param name="num">中控机机身号</param>
        ///// <param name="data">CMCustomOneBody 实体</param>
        ///// <exception cref="TimeoutException"></exception>
        ///// <returns></returns>
        //public static async Task<Message<bool>> CM_SetCustomOneAsync(string num, CMCustomOneSetting data)
        //{
        //    var api = Api.CM_SetCustomOne;
        //    var device = new Device(num);
        //    var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
        //    return message.Cast<bool>();
        //}

        /// <summary>
        /// 自定义智能设备 2
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMCustomTwoBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetCustomTwoAsync(string num, CMCustomTwoSetting data)
        {
            var api = Api.CM_SetCustomTwo;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 灯控开关
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMLightControlBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetLightControlAsync(string num, CMLightControlSetting data)
        {
            var api = Api.CM_SetLightControl;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 可调灯光设备
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMDimmerBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetDimmerAsync(string num, CMDimmerSetting data)
        {
            var api = Api.CM_SetDimmer;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 空调开关
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMAirSwitchBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetAirSwitchAsync(string num, CMAirSwitchSetting data)
        {
            var api = Api.CM_SetAirSwitch;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 插座
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMOutletBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetOutletAsync(string num, CMOutletSetting data)
        {
            var api = Api.CM_SetOutlet;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 窗帘
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMCurtainBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetCurtainAsync(string num, CMCurtainSetting data)
        {
            var api = Api.CM_SetCurtain;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 紧急按钮
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSecurityBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetUrgentbuttonAsync(string num, CMSecuritySetting data)
        {
            var api = Api.CM_SetUrgentButton;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 红外报警
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSecurityBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetInfraredAlarmAsync(string num, CMSecuritySetting data)
        {
            var api = Api.CM_SetInfraredAlarm;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 烟雾报警
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSecurityBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetSmokeAlarmAsync(string num, CMSecuritySetting data)
        {
            var api = Api.CM_SetSmokeAlarm;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 瓦斯报警
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSecurityBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetGasAlarmAsync(string num, CMSecuritySetting data)
        {
            var api = Api.CM_SetGasAlarm;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 门磁报警
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSecurityBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetDoorAlarmAsync(string num, CMSecuritySetting data)
        {
            var api = Api.CM_SetDoorAlarm;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 窗磁报警
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSecurityBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetWindowAlarmAsync(string num, CMSecuritySetting data)
        {
            var api = Api.CM_SetWindowAlarm;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 通用报警
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSecurityBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetGeneralAlarmAsync(string num, CMSecuritySetting data)
        {
            var api = Api.CM_SetGeneralAlarm;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 声光报警器
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSecurityBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetAcoustoAlarmAsync(string num, CMSecuritySetting data)
        {
            var api = Api.CM_SetAcoustoAlarm;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        ///// <summary>
        ///// 电视控制器
        ///// </summary>
        ///// <param name="num">中控机机身号</param>
        ///// <param name="data">CMTVControllerBody 实体</param>
        ///// <exception cref="TimeoutException"></exception>
        ///// <returns></returns>
        //public static async Task<Message<bool>> CM_SetTVControllerAsync(string num, CMTVControllerSetting data)
        //{
        //    var api = Api.CM_SetTVController;
        //    var device = new Device(num);
        //    var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
        //    return message.Cast<bool>();
        //}

        /// <summary>
        /// 单火线无线灯控开关
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSingleLightBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetSingleLightAsync(string num, CMSingleLightSetting data)
        {
            var api = Api.CM_SetSingleLight;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 中央空调
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CentralAir 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetCentralAirAsync(string num, CMCentralAirSetting data)
        {
            var api = Api.CM_SetCentralAir;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 新风系统设备
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CentralAir 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetFreshAirAsync(string num, CMFreshAirSetting data)
        {
            var api = Api.CM_SetFreshAir;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 设置百朗新风系统
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMBLFreshAirSetting 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetBLFreshAirAsync(string num, CMBLFreshAirSetting data)
        {
            var api = Api.CM_SetBLFreshAir;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 设置触摸灯控
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMTouchLightSetting 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetTouchLightAsync(string num, CMTouchLightSetting data)
        {
            var api = Api.CM_SetTouchLight;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 设置智能门锁
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">请求数据</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SmartLockOpenAsync(string num, CMCtrlRequest data)
        {
            var api = Api.CM_SmartLockOpen;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 设置智能门锁 - 钥匙管理
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMSmartLockSetting 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetSmartLockAsync(string num, CMSmartLockSetting data)
        {
            var api = Api.CM_SetSmartLock;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 设置智能门锁 - 获取钥匙列表
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">控制数据</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMSmartLockBody[]>> CM_GetSmartLockListAsync(string num, CMCtrlRequest data)
        {
            var api = Api.CM_GetSmartLockList;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMSmartLockBody[]>();
        }

        /// <summary>
        /// 设置智能门锁 - 临时密码管理
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CmTempPassWordSetting 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetTempPassWordAsync(string num, CMTempPassWordSetting data)
        {
            var api = Api.CM_SetTempPassWord;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 设置智能门锁 - 获取临时密码列表
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMCtrlRequest 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<CMTempPassWordBody[]>> CM_GetTempPassWordListAsync(string num, CMCtrlRequest data)
        {
            var api = Api.CM_GetTempPassWordList;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<CMTempPassWordBody[]>();
        }


        /// <summary>
        /// 风扇设备
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMFanBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetFanAsync(string num, CMFanSetting data)
        {
            var api = Api.CM_SetFan;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 无线门铃
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMDoorbellBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetDoorbellAsync(string num, CMDoorbellSetting data)
        {
            var api = Api.CM_SetDoorbell;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 免扰开关
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMDoorbellBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetImmunityAsync(string num, CMImmunitySetting data)
        {
            var api = Api.CM_SetImmunity;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }

        /// <summary>
        /// 背景音乐设备
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMBackgroundMusicBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetBackgroundMusicAsync(string num, CMBackgroundMusicSetting data)
        {
            var api = Api.CM_SetBackgroundMusic;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }


        /// <summary>
        /// 灯控总开关
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMBackgroundMusicBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetLampMasterAsync(string num, CMLampMasterSetting data)
        {
            var api = Api.CM_SetLampMaster;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }


        /// <summary>
        /// 无线红外设备
        /// </summary>
        /// <param name="num">中控机机身号</param>
        /// <param name="data">CMEntranceGuardBody 实体</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task<Message<bool>> CM_SetWirelessInfraredAsync(string num, CMSecuritySetting data)
        {
            var api = Api.CM_SetWirelessInfrared;
            var device = new Device(num);
            var message = await EmqttdClient.SendAsync(device.SubDevice, api, data);
            return message.Cast<bool>();
        }
    }
}
