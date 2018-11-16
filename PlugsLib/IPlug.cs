using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugsLib
{
    /// <summary>
    /// 插件接口
    /// </summary>
    public interface IPlug
    {
        /// <summary>
        /// 发送数据
        /// </summary>
        void OnSend();
    }
}
