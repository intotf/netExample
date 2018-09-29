using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugsLib.plugs
{
    /// <summary>
    /// 插件一
    /// </summary>
    public class PlugOne : PlugBase
    {
        /// <summary>
        /// 发送数据
        /// </summary>
        public override void OnSend()
        {
            Console.WriteLine(this.GetType().Name + "开始发送数据");
        }
    }
}
