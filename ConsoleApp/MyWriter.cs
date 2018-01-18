using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// 重写 TextWriter
    /// </summary>
    public class MyWriter : TextWriter
    {
        private readonly TextWriter consoleOut = Console.Out;

        public static MyWriter Out = new MyWriter();

        /// <summary>
        /// 获取编码
        /// </summary>
        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8; //test
            }
        }

        /// <summary>
        /// 输出字符串
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public override void Write(char[] buffer, int index, int count)
        {
            var value = new string(buffer, index, count);
            //清除换行
            //if (value.EndsWith(Environment.NewLine))
            //{
            //    value = new string(buffer, index, count - Environment.NewLine.Length);
            //}
            //控制台输出时前面增加时间
            consoleOut.Write(string.Format("{0} {1}", DateTime.Now, value));
            //System.Diagnostics.Debugger.Log(0, null, string.Format("{0} {1}", DateTime.Now, value));
        }
    }
}
