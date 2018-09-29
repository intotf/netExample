using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqMiddleware
{
    public class DemoData : IContenxt
    {

        public DemoData(Dictionary<string, object> dic, NotifData data)
        {
            this.Dic = dic;
            this.Data = data;
        }

        public Dictionary<string, object> Dic
        {
            get;
            private set;
        }

        public NotifData Data
        {
            get;
            private set;
        }
    }
}
