using Jiguang.JPush;
using Jiguang.JPush.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    /// <summary>
    /// 极光推送
    /// </summary>
    public static class JPusher
    {
        /// <summary>
        /// 极光客户端
        /// </summary>
        private static JPushClient client = new JPushClient("cb68cf8210cf8d301d64ec43", "a6bef52b45be2129395bc342");

        /// <summary>
        /// 消息推送
        /// </summary>
        /// <param name="clock"></param>
        public static void PushMsg(Clock clock)
        {
            var pushPayload = new PushPayload()
            {
                //推送平台设置
                Platform = new List<string> { "android", "ios" },
                //指定设备目标,all 全部设备
                //Audience = "all",
                //推送给多个注册 ID
                Audience = new
                {
                    registration_id = new string[] { "161a3797c87cc173a10" }
                },
                //通知内容体。是被推送到客户端的内容。与 message 一起二者必须有其一，可以二者并存
                Notification = new Notification
                {
                    IOS = new IOS
                    {
                        Alert = string.Format("{0} {1}", clock.RingTime, clock.Note),
                        Badge = "+1",
                        Sound = "sound.caf"
                    }
                },
                Options = new Options
                {
                    IsApnsProduction = false // 设置 iOS 推送生产环境。不设置默认为开发环境。
                }
            };
            client.SendPush(pushPayload);
        }

        /// <summary>
        /// 向某单个设备或者某设备列表推送一条通知、或者消息。
        /// </summary>
        public static void ExecutePushExample()
        {
            PushPayload pushPayload = new PushPayload()
            {
                //推送平台设置
                Platform = new List<string> { "android", "ios" },
                //指定设备目标,all 全部设备
                //Audience = "all",

                //推送给多个注册 ID
                Audience = new
                {
                    registration_id = new string[] { "161a3797c87cc173a10" }
                },

                //用于防止 api 调用端重试造成服务端的重复推送而定义的一个标识符。
                // CId = Guid.NewGuid().ToString(),

                //通知内容体。是被推送到客户端的内容。与 message 一起二者必须有其一，可以二者并存
                Notification = new Notification
                {
                    Alert = "hello jpush",
                    Android = new Android
                    {
                        Alert = "android alert",
                        Title = "title"
                    },
                    IOS = new IOS
                    {
                        Alert = "ios alert",
                        Badge = "+1",
                        Sound = "sound.caf"
                    }
                },
                //自定义消息
                Message = new Message
                {
                    Title = "message title",
                    Content = "message content",
                    Extras = new Dictionary<string, string>
                    {
                        ["key1"] = "value1"
                    }
                },
                Options = new Options
                {
                    IsApnsProduction = false // 设置 iOS 推送生产环境。不设置默认为开发环境。
                }
            };
            var response = client.SendPush(pushPayload);
            Console.WriteLine(response.Content);
        }


        /// <summary>
        /// 查询、设置、更新、删除设备的 tag，alias 信息
        /// </summary>
        private static void ExecuteDeviceEample()
        {
            var registrationId = "12145125123151";
            var devicePayload = new DevicePayload
            {
                Alias = "alias1",
                Mobile = "12300000000",
                Tags = new Dictionary<string, object>
                {
                    { "add", new List<string>() { "tag1", "tag2" } },
                    { "remove", new List<string>() { "tag3", "tag4" } }
                }
            };
            var response = client.Device.UpdateDeviceInfo(registrationId, devicePayload);
            Console.WriteLine(response.Content);
        }


        /// <summary>
        /// 提供各类统计数据查询功能
        /// </summary>
        private static void ExecuteReportExample()
        {
            var response = client.Report.GetMessageReport(new List<string> { "1251231231" });
            Console.WriteLine(response.Content);
        }


        /// <summary>
        /// 定时或定期任务测试
        /// </summary>
        private static void ExecuteScheduleExample()
        {
            var pushPayload = new PushPayload
            {
                Platform = "all",
                Notification = new Notification
                {
                    Alert = "Hello JPush"
                }
            };
            var trigger = new Trigger
            {
                StartDate = "2017-08-03 12:00:00",
                EndDate = "2017-12-30 12:00:00",
                TriggerTime = "12:00:00",
                TimeUnit = "week",
                Frequency = 2,
                TimeList = new List<string>
                {
                    "wed", "fri"
                }
            };
            var response = client.Schedule.CreatePeriodicalScheduleTask("task1", pushPayload, trigger);
            Console.WriteLine(response.Content);
        }
    }
}
