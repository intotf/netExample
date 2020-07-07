using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;

namespace BackupsZip
{
    /// <summary>
    /// 压缩的方法
    /// </summary>
    public class ZipFloClass
    {
        /// <summary>
        /// 文件压缩
        /// </summary>
        /// <param name="strFile">文件/目录</param>
        /// <param name="strZip">压缩包路径</param>
        /// <param name="level">压缩等级0-9</param>
        public static void ZipFile(string strFile, string strZip, int level = 6)
        {
            var len = strFile.Length;
            var strlen = strFile[len - 1];
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar)
            {
                strFile += Path.DirectorySeparatorChar;
            }
            ZipOutputStream outstream = new ZipOutputStream(File.Create(strZip));
            outstream.SetLevel(level);
            zip(strFile, outstream, strFile);
            outstream.Finish();
            outstream.Close();
        }

        /// <summary>
        /// 文件夹压缩
        /// </summary>
        /// <param name="strFile"></param>
        /// <param name="outstream"></param>
        /// <param name="staticFile"></param>
        private static void zip(string strFile, ZipOutputStream outstream, string staticFile)
        {
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar)
            {
                strFile += Path.DirectorySeparatorChar;
            }
            var crc = new Crc32();
            //获取指定目录下所有文件和子目录文件名称
            var filenames = Directory.GetFileSystemEntries(strFile);
            //遍历文件
            foreach (string file in filenames)
            {
                if (Directory.Exists(file))
                {
                    zip(file, outstream, staticFile);
                }
                //否则，直接压缩文件
                else
                {
                    //打开文件
                    FileStream fs = File.OpenRead(file);
                    //定义缓存区对象
                    byte[] buffer = new byte[fs.Length];
                    //通过字符流，读取文件
                    fs.Read(buffer, 0, buffer.Length);
                    //得到目录下的文件（比如:D:\Debug1\test）,test
                    string tempfile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                    ZipEntry entry = new ZipEntry(tempfile);
                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;
                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    outstream.PutNextEntry(entry);
                    //写文件
                    outstream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
