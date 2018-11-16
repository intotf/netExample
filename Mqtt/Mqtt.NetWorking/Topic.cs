using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.NetWorking
{
    /// <summary>
    /// 表示主题
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// 获取主题
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// 获取主题参数值 
        /// </summary>
        public string[] Args { get; set; }

        /// <summary>
        /// 表示主题
        /// </summary>
        /// <param name="format">格式</param>
        /// <param name="args">参数</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Topic(string format, params string[] args)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException();
            }
            this.Value = string.Format(format, args);
            this.Args = args;
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Value;
        }
    }
}
