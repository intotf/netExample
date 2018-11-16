using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    /// <summary>
    /// HttpClient
    /// </summary>
    public class HttpApiClient : HttpClient
    {
        /// <summary>
        /// 获取默认实例的HttpApiClient
        /// </summary>
        public static readonly HttpApiClient Default = new HttpApiClient();
    }
}
