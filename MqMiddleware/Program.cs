using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("key", "value");
            var notifData = new NotifData { Title = "aaa", Content = DateTime.Now.ToFileTimeUtc().ToString() };
            var ms = new MiddlewareManager();
            ms.Use<OneMiddlerware>(new Config { });
            ms.Use<TwoMiddlerware>(new YiYingCong { Other = "df", Host = new Uri("http://www.baidu.com") });


            while (true)
            {
                var title = Console.ReadLine();
                notifData.Title = title;
                var model = new DemoData(dic, notifData);
                ms.RaiseInvoke(model);
            }
        }
    }
}
