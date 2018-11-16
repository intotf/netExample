using HDP.Model.Dtos;
using HDP.Networking.Bodies;
using HDP.Networking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// Mqtt指令枚举
    /// </summary>
    public enum Api : int
    {
        /// <summary>
        /// 测试数据指令
        /// </summary>
        [Body(typeof(TimeoutDataSetting), ReturnType = typeof(string))]
        Sys_TestData = 1,

        /// <summary>
        /// 要求上传日志指令
        /// </summary>
        [Body(typeof(UploadLogSetting), RequestMode = Mode.Post)]
        Sys_UploadLog = 2,


        /// <summary>
        /// 控制(重启、启用、禁用）
        /// </summary>
        [Body(typeof(SysCtrlSetting), ReturnType = typeof(bool))]
        Sys_Control = 3,

        /// <summary>
        /// 门口机Post用户自定义数据指令
        /// </summary>
        [Body(typeof(string), ReturnType = typeof(EmptyInfo), RequestMode = Mode.Post)]
        EM_CustomData_Post = 100,


        /// <summary>
        /// 门口机Send用户自定义数据指令
        /// </summary>
        [Body(typeof(TimeoutDataSetting), ReturnType = typeof(EmptyInfo), RequestMode = Mode.Send)]
        EM_CustomData_Send = 101,


        /// <summary>
        /// 门口机开锁指令
        /// </summary>
        [Body(typeof(TimeoutDataSetting), ReturnType = typeof(bool))]
        EM_Unlock = 1000,

        /// <summary>
        /// 获取中控机的设备列表
        /// </summary>
        [Body(typeof(TimeoutRequest), ReturnType = typeof(CMDeivceData))]
        CM_GetDeviceList = 2000,

        /// <summary>
        /// 获取中控机的情景模式列表
        /// </summary>
        [Body(typeof(TimeoutRequest), ReturnType = typeof(CMSceneInfo[]))]
        CM_GetSceneList = 2001,

        /// <summary>
        /// 中控机的设备报警
        /// </summary>
        [Body(typeof(CMAlarmInfo), IsClientRequest = true, RequestMode = Mode.Post)]
        CM_RaiseAlarm = 2002,


        /// <summary>
        /// 设置中控机的情景模式
        /// </summary>
        [Body(typeof(CMSceneSetting), ReturnType = typeof(bool))]
        CM_SetScene = 2003,

        ///// <summary>
        ///// 智能家居自定义发送消息到业务平台
        ///// </summary>
        //[Body(typeof(CmCustomInfo), IsClientRequest = true, RequestMode = Mode.Post)]
        //CM_RaiseCustom = 2004,

        ///// <summary>
        ///// 智能家居-智能门锁-临时密码发送消息到业务平台
        ///// </summary>
        //[Body(typeof(CMTempPassWordInfo), IsClientRequest = true, RequestMode = Mode.Post)]
        //CM_RaiseTempPassWord = 2005,

        ///// <summary>
        ///// 智能家居-智能门锁-钥匙管理
        ///// </summary>
        //[Body(typeof(CMSmartLockInfo), IsClientRequest = true, RequestMode = Mode.Post)]
        //CM_RaiseSmartLock = 2006,

        /// <summary>
        /// 智能家居-智能门锁-开锁日志
        /// </summary>
        [Body(typeof(CMOpenRecordInfo), IsClientRequest = true, RequestMode = Mode.Post)]
        CM_RaiseOpenRecord = 2007,

        /// <summary>
        /// 获取智能门锁钥匙列表
        /// </summary>
        [Body(typeof(CMCtrlRequest), ReturnType = typeof(CMSmartLockBody[]))]
        CM_GetSmartLockList = 2008,

        /// <summary>
        /// 获取智能门锁临时钥匙列表
        /// </summary>
        [Body(typeof(CMCtrlRequest), ReturnType = typeof(CMTempPassWordBody[]))]
        CM_GetTempPassWordList = 2009,

        ///// <summary>
        ///// 设置智能空调控制
        ///// </summary>
        //[Body(typeof(CMAirSetting), ReturnType = typeof(bool))]
        //CM_SetAir = 3001,

        /// <summary>
        /// 设置恒亦明LED控制器
        /// </summary>
        [Body(typeof(CMLedSetting), ReturnType = typeof(bool))]
        CM_SetLed = 3002,

        ///// <summary>
        ///// 设置智能电视
        ///// </summary>
        //[Body(typeof(CMTVSetting), ReturnType = typeof(bool))]
        //CM_SetTV = 3003,

        ///// <summary>
        ///// 设置智能机顶盒
        ///// </summary>
        //[Body(typeof(CMTopboxSetting), ReturnType = typeof(bool))]
        //CM_SetTopbox = 3004,

        ///// <summary>
        ///// 设置智能DVD
        ///// </summary>
        //[Body(typeof(CMDvdSetting), ReturnType = typeof(bool))]
        //CM_SetDvd = 3005,

        ///// <summary>
        ///// 设置自定义智能设备 1
        ///// </summary>
        //[Body(typeof(CMCustomOneSetting), ReturnType = typeof(bool))]
        //CM_SetCustomOne = 3006,

        /// <summary>
        /// 设置自定义智能设备 2
        /// </summary>
        [Body(typeof(CMCustomTwoSetting), ReturnType = typeof(bool))]
        CM_SetCustomTwo = 3007,

        /// <summary>
        /// 设置灯控开关
        /// </summary>
        [Body(typeof(CMLightControlSetting), ReturnType = typeof(bool))]
        CM_SetLightControl = 3008,

        /// <summary>
        /// 设置调光开关
        /// </summary>
        [Body(typeof(CMDimmerSetting), ReturnType = typeof(bool))]
        CM_SetDimmer = 3009,

        /// <summary>
        /// 设置空调开关
        /// </summary>
        [Body(typeof(CMAirSwitchSetting), ReturnType = typeof(bool))]
        CM_SetAirSwitch = 3010,

        /// <summary>
        /// 设置插座
        /// </summary>
        [Body(typeof(CMOutletSetting), ReturnType = typeof(bool))]
        CM_SetOutlet = 3011,

        /// <summary>
        /// 设置窗帘
        /// </summary>
        [Body(typeof(CMCurtainSetting), ReturnType = typeof(bool))]
        CM_SetCurtain = 3012,


        /// <summary>
        /// 设置紧急按钮
        /// </summary>
        [Body(typeof(CMSecuritySetting), ReturnType = typeof(bool))]
        CM_SetUrgentButton = 3013,

        /// <summary>
        /// 设置红外报警
        /// </summary>
        [Body(typeof(CMSecuritySetting), ReturnType = typeof(bool))]
        CM_SetInfraredAlarm = 3014,

        /// <summary>
        /// 设置烟雾报警
        /// </summary>
        [Body(typeof(CMSecuritySetting), ReturnType = typeof(bool))]
        CM_SetSmokeAlarm = 3015,

        /// <summary>
        /// 设置瓦斯报警
        /// </summary>
        [Body(typeof(CMSecuritySetting), ReturnType = typeof(bool))]
        CM_SetGasAlarm = 3016,

        /// <summary>
        /// 门磁报警
        /// </summary>
        [Body(typeof(CMSecuritySetting), ReturnType = typeof(bool))]
        CM_SetDoorAlarm = 3017,

        /// <summary>
        /// 设置窗磁报警
        /// </summary>
        [Body(typeof(CMSecuritySetting), ReturnType = typeof(bool))]
        CM_SetWindowAlarm = 3018,

        /// <summary>
        /// 设置通用报警
        /// </summary>
        [Body(typeof(CMSecuritySetting), ReturnType = typeof(bool))]
        CM_SetGeneralAlarm = 3019,

        /// <summary>
        /// 设置声光报警器
        /// </summary>
        [Body(typeof(CMSecuritySetting), ReturnType = typeof(bool))]
        CM_SetAcoustoAlarm = 3020,

        ///// <summary>
        ///// 设置电视控制器
        ///// </summary>
        //[Body(typeof(CMTVControllerSetting), ReturnType = typeof(bool))]
        //CM_SetTVController = 3021,


        /// <summary>
        /// 设置单火线无线灯控开关
        /// </summary>
        [Body(typeof(CMSingleLightSetting), ReturnType = typeof(bool))]
        CM_SetSingleLight = 3022,

        /// <summary>
        /// 设置中央空调
        /// </summary>
        [Body(typeof(CMCentralAirSetting), ReturnType = typeof(bool))]
        CM_SetCentralAir = 3023,


        /// <summary>
        /// 设置新风系统设备
        /// </summary>
        [Body(typeof(CMFreshAirSetting), ReturnType = typeof(bool))]
        CM_SetFreshAir = 3024,

        /// <summary>
        /// 设置风扇
        /// </summary>
        [Body(typeof(CMFanSetting), ReturnType = typeof(bool))]
        CM_SetFan = 3025,

        /// <summary>
        /// 设置无线门铃
        /// </summary>
        [Body(typeof(CMDoorbellSetting), ReturnType = typeof(bool))]
        CM_SetDoorbell = 3026,

        /// <summary>
        /// 设置免扰开关
        /// </summary>
        [Body(typeof(CMImmunitySetting), ReturnType = typeof(bool))]
        CM_SetImmunity = 3027,

        /// <summary>
        /// 设置背景音乐设备
        /// </summary>
        [Body(typeof(CMBackgroundMusicSetting), ReturnType = typeof(bool))]
        CM_SetBackgroundMusic = 3028,

        /// <summary>
        /// 设置灯控总开关
        /// </summary>
        [Body(typeof(CMLampMasterSetting), ReturnType = typeof(bool))]
        CM_SetLampMaster = 3029,

        /// <summary>
        /// 设置无线红外设备
        /// </summary>
        [Body(typeof(CMSecuritySetting), ReturnType = typeof(bool))]
        CM_SetWirelessInfrared = 3031,



        /// <summary>
        /// 获取红外空调按键学习状态
        /// </summary>
        [Body(typeof(TimeoutRequest), ReturnType = typeof(CMInfAirKeyState[]))]
        CM_GetInfAirKeys = 3100,

        /// <summary>
        /// 红外按键学习
        /// </summary>
        [Body(typeof(CMInfAirKeyCtrl), ReturnType = typeof(bool))]
        CM_LearnInfAirKey = 3101,

        /// <summary>
        /// 设置红外空调
        /// </summary>
        [Body(typeof(CMInfAirKeyCtrl), ReturnType = typeof(bool))]
        CM_SetInfAir = 3102,

        /// <summary>
        /// 获取红外电视按键学习状态
        /// </summary>
        [Body(typeof(TimeoutRequest), ReturnType = typeof(CMInfTvKeyState[]))]
        CM_GetInfTvKeys = 3103,

        /// <summary>
        /// 红外电视按键学习
        /// </summary>
        [Body(typeof(CMInfTvKeyCtrl), ReturnType = typeof(bool))]
        CM_LearnInfTvKey = 3104,

        /// <summary>
        /// 设置红外电视
        /// </summary>
        [Body(typeof(CMInfTvKeyCtrl), ReturnType = typeof(bool))]
        CM_SetInfTv = 3105,

        /// <summary>
        /// 获取红外机顶盒按键学习状态
        /// </summary>
        [Body(typeof(TimeoutRequest), ReturnType = typeof(CMInfTopboxKeyState[]))]
        CM_GetInfTopboxKeys = 3106,

        /// <summary>
        /// 红外机顶盒按键学习
        /// </summary>
        [Body(typeof(CMInfTopboxKeyCtrl), ReturnType = typeof(bool))]
        CM_LearnInfTopboxKey = 3107,

        /// <summary>
        /// 设置红外机顶盒
        /// </summary>
        [Body(typeof(CMInfTopboxKeyCtrl), ReturnType = typeof(bool))]
        CM_SetInfTopbox = 3108,

        /// <summary>
        /// 获取红外DVD按键学习状态
        /// </summary>
        [Body(typeof(TimeoutRequest), ReturnType = typeof(CMInfDvdKeyState[]))]
        CM_GetInfDvdKeys = 3109,

        /// <summary>
        /// 红外DVD按键学习
        /// </summary>
        [Body(typeof(CMInfDvdKeyCtrl), ReturnType = typeof(bool))]
        CM_LearnInfDvdKey = 3110,

        /// <summary>
        /// 设置红外DVD
        /// </summary>
        [Body(typeof(CMInfDvdKeyCtrl), ReturnType = typeof(bool))]
        CM_SetInfDvd = 3111,

        /// <summary>
        /// 获取红外 [自定义遥控器1] 按键学习状态
        /// </summary>
        [Body(typeof(TimeoutRequest), ReturnType = typeof(CMInfTeleOneKeyState[]))]
        CM_GetInfTeleOneKeys = 3112,

        /// <summary>
        /// 红外 [自定义遥控器1] 按键学习
        /// </summary>
        [Body(typeof(CMInfTeleOneKeyCtrl), ReturnType = typeof(bool))]
        CM_LearnInfTeleOneKey = 3113,

        /// <summary>
        /// 设置红外 [自定义遥控器1] 
        /// </summary>
        [Body(typeof(CMInfTeleOneKeyCtrl), ReturnType = typeof(bool))]
        CM_SetInfTeleOne = 3114,

        /// <summary>
        /// 获取红外 [自定义遥控器2] 按键学习状态
        /// </summary>
        [Body(typeof(TimeoutRequest), ReturnType = typeof(CMInfTeleTwoKeyState[]))]
        CM_GetInfTeleTwoKeys = 3115,

        /// <summary>
        /// 红外 [自定义遥控器2] 按键学习
        /// </summary>
        [Body(typeof(CMInfTeleTwoKeyCtrl), ReturnType = typeof(bool))]
        CM_LearnInfTeleTwoKey = 3116,

        /// <summary>
        /// 设置红外 [自定义遥控器2] 
        /// </summary>
        [Body(typeof(CMInfTeleTwoKeyCtrl), ReturnType = typeof(bool))]
        CM_SetInfTeleTwo = 3117,


        /// <summary>
        /// 设置百朗新风系统
        /// </summary>
        [Body(typeof(CMBLFreshAirSetting), ReturnType = typeof(bool))]
        CM_SetBLFreshAir = 3118,

        /// <summary>
        /// 设置触摸灯控
        /// </summary>
        [Body(typeof(CMTouchLightSetting), ReturnType = typeof(bool))]
        CM_SetTouchLight = 3119,

        /// <summary>
        /// 开智能门锁
        /// </summary>
        [Body(typeof(CMCtrlRequest), ReturnType = typeof(bool))]
        CM_SmartLockOpen = 3120,


        /// <summary>
        /// 智能门锁-钥匙管理
        /// </summary>
        [Body(typeof(CMSmartLockSetting), ReturnType = typeof(bool))]
        CM_SetSmartLock = 3121,

        /// <summary>
        /// 智能门锁-临时密码管理
        /// </summary>
        [Body(typeof(CMTempPassWordSetting), ReturnType = typeof(bool))]
        CM_SetTempPassWord = 3122,

        /// <summary>
        /// 推送Post用户自定义数据指令
        /// </summary>
        [Body(typeof(string), ReturnType = typeof(EmptyInfo), RequestMode = Mode.Post)]
        Push_CustomData_Post = 4000,


        /// <summary>
        /// 推送Send用户自定义数据指令
        /// </summary>
        [Body(typeof(TimeoutDataSetting), ReturnType = typeof(EmptyInfo), RequestMode = Mode.Send)]
        Push_CustomData_Send = 4001,
    }


}
