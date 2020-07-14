using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            var readlen = 4096000;
            //获取指定目录下所有文件和子目录文件名称
            var filenames = Directory.GetFileSystemEntries(strFile);
            //遍历文件
            foreach (string file in filenames)
            {
                try
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
                        byte[] buffer = new byte[readlen];
                        var remaindSize = fs.Length;
                        var allbuffer = new byte[remaindSize];

                        //得到目录下的文件（比如:D:\Debug1\test）,test
                        string tempfile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                        ZipEntry entry = new ZipEntry(tempfile);

                        // 计算crc
                        while (remaindSize > 0)
                        {
                            crc.Reset();
                            if (remaindSize < readlen)
                                readlen = (int)remaindSize;

                            fs.Read(buffer, 0, readlen);
                            remaindSize -= readlen;
                            crc.Update(buffer);
                        }
                        entry.Crc = crc.Value;
                        outstream.PutNextEntry(entry);

                        // 压缩数据
                        readlen = 4096000;
                        remaindSize = fs.Length;
                        fs.Seek(0, SeekOrigin.Begin);
                        while (remaindSize > 0)
                        {
                            if (remaindSize < readlen)
                                readlen = (int)remaindSize;

                            fs.Read(buffer, 0, readlen);
                            remaindSize -= readlen;
                            outstream.Write(buffer, 0, readlen);
                        }
                        fs.Close();
                        crc.Reset();

                        ////通过字符流，读取文件
                        //fs.Read(buffer, 0, buffer.Length);

                        ////得到目录下的文件（比如:D:\Debug1\test）,test
                        //string tempfile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                        //ZipEntry entry = new ZipEntry(tempfile);

                        //entry.DateTime = DateTime.Now;
                        //entry.Size = fs.Length;


                        //fs.Close();
                        //crc.Reset();
                        //crc.Update(buffer);
                        //entry.Crc = crc.Value;
                        //outstream.PutNextEntry(entry);
                        ////写文件
                        //outstream.Write(buffer, 0, buffer.Length);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Default.LogError(new EventId(1), ex, file);
                }
            }
        }
    }
}
