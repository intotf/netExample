using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveLib
{
    public class RS
    {
        /// <summary>
        /// 获取资源的流
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Stream GetStream(string file)
        {
            var name = $"{typeof(RS).Namespace}.{file}";
            return typeof(RS).Assembly.GetManifestResourceStream(name);
        }

        /// <summary>
        /// 获取资源文本
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetString(string file)
        {
            using (var stream = GetStream(file))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// 获取图标资源
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Icon GetIcon(string file)
        {
            var stream = GetStream(file);
            return new Icon(stream);
        }
    }
}
