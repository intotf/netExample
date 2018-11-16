using MqttConsole.Tasks;
using Paho.MqttDotnet;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mqtt.NetWorking;

namespace MqttConsole
{
    class Program
    {
        //private static MqttClient mqttService = MqttClient.Instance("mqtt://127.0.0.1", "123456");

        /// <summary>
        /// 任务表
        /// </summary>
        private static readonly TaskSetterTable<string> taskTable = new TaskSetterTable<string>();

        static void Main(string[] args)
        {

            //mqttService.Subscribe("world");

            //mqttService.SendMessage("我已经连接上");

            //mqttService.OnMessage -= MqttService_OnMessage;
            //mqttService.OnMessage += MqttService_OnMessage;

            //var dic = new ConcurrentDictionary<int, Reader>();

            //while (true)
            //{
            //    var text = Console.ReadLine();
            //    if (!string.IsNullOrEmpty(text))
            //    {

            //        var taskSetter = taskTable.Create<string>("123456", TimeSpan.FromSeconds(5));
            //        mqttService.SendMessage(text);

            //        try
            //        {
            //            ResultTask();
            //            var result = taskSetter.GetTask().Result;
            //            Console.WriteLine(result);
            //        }
            //        catch (AggregateException ex)
            //        {
            //            Console.WriteLine(ex.InnerException.Message);
            //        }

            //    }
            //}
            Console.ReadKey();
        }


        static void MqttService_OnMessage(MqttMessage msg)
        {
            Console.WriteLine(msg.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        static void ResultTask()
        {
            Thread.Sleep(1000);
            var resultTaks = taskTable.Remove("123456");
            resultTaks.SetResult("回复消息了");
        }
    }

    class Reader
    {
        TaskCompletionSource<int> tcs1 = new TaskCompletionSource<int>();

        public void Read()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.ReadKey();
                tcs1.SetResult(15);
            });
        }

        public Task<int> GetTask()
        {
            return tcs1.Task;
        }
    }
}
