using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOSerialize
{
    /// <summary>
    /// 文件管理
    /// 1.C# 常用三大流：文件流 FileStream; 内存流 MemoryStream; 网络流 NetworkStream
    /// 2.流转为二进制, byte[] bytes = new byte[stream.Length];  stream.Write(bytes, 0, bytes.Length);
    /// 3.二进制 转 string Encoding.Default.GetString
    /// 4.文件的基本操作;  StringBuilder 的使用.
    /// </summary>
    public class FileHelp
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        private readonly string _file;

        /// <summary>
        /// 文件是否存在
        /// </summary>
        private readonly bool IsExist = false;

        /// <summary>
        /// 内容
        /// </summary>
        private readonly StringBuilder sb = new StringBuilder();

        private FileHelp(string file)
        {
            this._file = file;
            this.IsExist = File.Exists(file);
        }

        /// <summary>
        /// 设置文件名称
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static FileHelp Set(string file)
        {
            return new FileHelp(file);
        }

        /// <summary>
        /// 设置文件名称,需带上后缀名
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static FileHelp SetToDay(string file)
        {
            file = string.Format("{0}_{1}{2}",
                Path.GetFileNameWithoutExtension(file),     //获取文件名不带后缀
                DateTime.Now.ToString("yyyyMMdd"),
                Path.GetExtension(file));                   //获取文件后缀名如：".txt"
            return new FileHelp(file);
        }

        /// <summary>
        /// 获取文件信息
        /// </summary>
        public FileInfo GetFileInfo()
        {
            if (!IsExist)
            {
                return null;
            }
            return new FileInfo(this._file);
        }

        /// <summary>
        /// 读取文件转为byte[]
        /// </summary>
        /// <returns></returns>
        public byte[] ReadByBytes()
        {
            if (!IsExist)
            {
                return null;
            }
            return File.ReadAllBytes(this._file);
        }

        /// <summary>
        /// 读取文件流到内存流
        /// </summary>
        /// <returns></returns>
        public MemoryStream ReadByMemoryStream()
        {
            if (!IsExist)
            {
                return null;
            }
            var fileStream = File.OpenRead(this._file);
            //var bytes = new byte[fileStream.Length];
            //fileStream.Read(bytes, 0, (int)fileStream.Length);
            //var newStream = new MemoryStream(bytes);
            var newStream = new MemoryStream();
            fileStream.Position = 0;    //必需要重置流的位置
            fileStream.CopyTo(newStream);
            fileStream.Close();       //释放文件流
            return newStream;
        }

        /// <summary>
        /// 读取文件转为字符串
        /// </summary>
        /// <returns></returns>
        public string ReadByString()
        {
            if (!IsExist)
            {
                return string.Empty;
            }
            return File.ReadAllText(this._file);
        }

        /// <summary>
        /// 增加文本内容
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public FileHelp Append(object obj)
        {
            if (obj != null)
            {
                this.sb.Append(obj.ToString());
            }
            return this;
        }

        /// <summary>
        /// 增加自定义参数内容
        /// </summary>
        /// <param name="obj">日志</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public FileHelp Append(object obj, params object[] args)
        {
            if (obj != null)
            {
                var logTxt = string.Format(obj.ToString(), args);
                this.sb.Append(logTxt);
            }
            return this;
        }

        /// <summary>
        /// 增加换行文本
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public FileHelp AppendLine(object obj)
        {
            if (obj != null)
            {
                this.sb.AppendLine(obj.ToString());
            }
            return this;
        }

        /// <summary>
        /// 增加换行自定义参数内容
        /// </summary>
        /// <param name="obj">日志</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public FileHelp AppendLine(object obj, params object[] args)
        {
            if (obj != null)
            {
                this.sb.AppendLine(string.Format(obj.ToString(), args));
            }
            return this;
        }

        /// <summary>
        /// 增加换行，任意对象转换为 Json 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public FileHelp AppendLineAsJson<T>(T data)
        {
            if (data != null)
            {
                this.sb.AppendLine(JsonSerializer.Serialize(data));
            }
            return this;
        }

        /// <summary>
        /// 保存 Append 数据到文件
        /// </summary>
        public void SaveAppend()
        {
            File.AppendAllText(this._file, sb.ToString());
            sb.Clear();
        }

        /// <summary>
        /// 获取文件类型 
        /// </summary>
        /// <returns></returns>
        public FileType GetFileType()
        {
            if (!IsExist)
            {
                return FileType.Uunknown;
            }
            var fileStream = File.OpenRead(this._file);
            BinaryReader reader = new BinaryReader(fileStream);
            string fileclass = "";
            //这里的位长要具体判断. 
            byte buffer;
            try
            {
                buffer = reader.ReadByte();
                fileclass = buffer.ToString();
                buffer = reader.ReadByte();
                fileclass += buffer.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            fileStream.Close();
            reader.Close();
            return (FileType)int.Parse(fileclass);
        }

        /// <summary>
        /// 根据文件流保存文件
        /// </summary>
        /// <param name="stream"></param>
        public void StreamSave(FileStream stream)
        {
            // 把 Stream 转换成 byte[]
            byte[] bytes = new byte[stream.Length];
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Dispose();
        }

        /// <summary>
        /// 根据内存流保存文件
        /// </summary>
        /// <param name="stream"></param>
        public void StreamSave(MemoryStream stream, string tempPath = "")
        {
            if (string.IsNullOrEmpty(tempPath))
            {
                tempPath = Guid.NewGuid().ToString().Replace("-", "") + ".txt";
            }
            // 把 byte[] 写入临时文件
            FileStream fs = new FileStream(tempPath, FileMode.Create);
            stream.WriteTo(fs);

            #region 方式二,将流读成 byte[]，在写入文件
            //// 设置当前流的位置为流的开始
            //stream.Seek(0, SeekOrigin.Begin);
            //// 把 Stream 转换成 byte[]
            //byte[] bytes = new byte[stream.Length];
            //stream.Read(bytes, 0, bytes.Length);

            //// 把 byte[] 写入临时文件
            //FileStream fs = new FileStream(tempPath, FileMode.Create);
            //BinaryWriter bw = new BinaryWriter(fs);
            //bw.Write(bytes);
            //bw.Close();
            #endregion
            fs.Close();
            stream.Dispose();
            stream.Close();
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        public void Delete()
        {
            File.Delete(this._file);
        }

        #region 文件流/字节处理
        /// <summary>
        /// 读取字节指定长度转换为 字符串
        /// </summary>
        /// <param name="bytes">字节</param>
        /// <param name="offset">读取的开始位</param>
        /// <param name="count">总共获取长度</param>
        /// <returns></returns>
        public static string ReadByString(byte[] bytes, int offset, int count)
        {
            var readbytes = FileHelp.BytesCopy(bytes, offset, count);
            return Encoding.Default.GetString(readbytes);
        }

        /// <summary>
        /// 从文件流中读取文件指定长度
        /// </summary>
        /// <param name="fileStream">文件流</param>
        /// <param name="offset">读取的开始位</param>
        /// <param name="count">总共获取长度</param>
        /// <param name="ReadCount">返回可以字节数</param>
        /// <returns></returns>
        public static byte[] ReadByFileStream(FileStream fileStream, int offset, int count, out int ReadCount)
        {
            byte[] arr = new byte[count]; // 要读取的字节数
            fileStream.Position = offset;
            //文件编码 ,使用无签名
            ReadCount = fileStream.Read(arr, 0, count);
            return arr;
        }

        /// <summary>
        /// 从文件流中读取文件指定长度
        /// </summary>
        /// <param name="fileStream">文件流</param>
        /// <param name="offset">读取的开始位</param>
        /// <param name="count">总共获取长度</param>
        /// <param name="ReadCount">返回可以字节数</param>
        /// <returns></returns>
        public static byte[] BytesCopy(byte[] bytes, int offset, int count)
        {
            var newBytes = new byte[count];
            Array.Copy(bytes, offset, newBytes, 0, count);
            return newBytes;
        }
        #endregion
    }
}
