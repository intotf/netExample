using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace AlarmClock
{
    /// <summary>
    /// 钉钉机器人
    /// </summary>
    public class Dingtalk
    {
        /// <summary>
        /// 钉钉请求Api
        /// </summary>
        public static string apiUrl = System.Configuration.ConfigurationManager.AppSettings["DingtalkApi"];

        /// <summary>
        /// 秘钥
        /// </summary>
        public static string secret = System.Configuration.ConfigurationManager.AppSettings["DingtalkSecret"];

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="message"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        private static string CreateSign(string message)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        /// <summary>
        /// 发送钉钉通知
        /// </summary>
        /// <returns></returns>
        public static bool Notice(string msg)
        {
            if (string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(secret))
            {
                return false;
            }
            var model = new
            {
                msgtype = "text",
                text = new
                {
                    content = msg
                }
            };
            var json = JsonConvert.SerializeObject(model);

            var timestamp = CurrentTimeStamp().ToString();
            var signStr = timestamp + "\n" + secret;
            var sign = CreateSign(signStr);

            var url = string.Format(apiUrl + "&timestamp={0}&sign={1}", timestamp, sign);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var resultModel = JsonConvert.DeserializeObject<ApiResult>(result);
                return resultModel.errcode == "0";
            }
        }


        /// <summary>
        /// 创时间戳
        /// </summary>
        /// <param name="isMinseconds">是否毫秒</param>
        /// <returns></returns>
        private static long CurrentTimeStamp(bool isMinseconds = true)
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long times = Convert.ToInt64(isMinseconds ? ts.TotalMilliseconds : ts.TotalSeconds);
            return times;
        }
    }

    public class ApiResult
    {
        public string errcode { get; set; }

        public string errmsg { get; set; }
    }
}
