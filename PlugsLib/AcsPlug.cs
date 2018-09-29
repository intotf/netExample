using PlugsLib.plugs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugsLib
{
    public class AcsPlug
    {
        /// <summary>
        /// 所有加载的插件集合
        /// </summary>
        private readonly static List<IPlug> acsPlugs = new List<IPlug>();

        /// <summary>
        /// 加载插件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="plug"></param>
        /// <returns></returns>
        public void LoadPlugs<T>() where T : IPlug
        {
            var plug = Activator.CreateInstance<T>();
            acsPlugs.Add(plug);
        }

        /// <summary>
        /// 开始运行插件
        /// </summary>
        public void Start()
        {
            foreach (var plug in acsPlugs)
            {
                plug.OnSend();
            }
        }
    }
}
