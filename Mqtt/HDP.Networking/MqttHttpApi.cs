using HDP.Common.Utility;
using HDP.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Networking
{
    /// <summary>
    /// 表示emqttd的http接口
    /// </summary>
    public class MqttHttpApi
    {
        /// <summary>
        /// http接口配置
        /// </summary>
        private readonly MqttPubsub httpApi;

        /// <summary>
        /// emqttd的http接口
        /// </summary>
        /// <param name="httpApi">http接口配置</param>
        public MqttHttpApi(MqttPubsub httpApi)
        {
            this.httpApi = httpApi;
        }

        /// <summary>
        /// 获取在线的客户端的信息
        /// 不在线返回null
        /// </summary>
        /// <param name="clientId">客户端id</param>
        /// <returns></returns>
        public async Task<ClientInfo> GetClientAsync(string clientId)
        {
            var path = string.Format("/api/clients?curr_page=1&page_size=1&client_key={0}", clientId);
            var address = new Uri(httpApi.Address).Combine(path);

            var basic = string.Format("{0}:{1}", httpApi.Account, httpApi.Password);
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(basic));

            var request = new HttpRequestMessage(HttpMethod.Get, address);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64);

            var response = await HttpApiClient.Default.SendAsync(request);
            var body = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            var page = JsonSerializer.TryDeserialize<EmqttPage<ClientInfo>>(body);

            if (page == null)
            {
                return null;
            }
            return page.result.FirstOrDefault();
        }

        /// <summary>
        /// 表示emqttd的分页信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class EmqttPage<T>
        {
            public int currentPage { get; set; }
            public int pageSize { get; set; }
            public int totalNum { get; set; }
            public int totalPage { get; set; }
            public T[] result { get; set; }
        }
    }
}
