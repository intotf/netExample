using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace IOSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetOut(new MyWrite());
            #region 常规文件
            var filer = FileHelp.Set("HTMLPage.html");
            var myStream = filer.ReadByMemoryStream();
            filer.StreamSave(myStream);
            var fileinfo = filer.GetFileInfo();
            fileinfo.CopyTo("new.html", true);
            filer.Append("aaaa").AppendLineAsJson(new { a = 1, b = 2, c = 3 }).SaveAppend();
            #endregion

            #region 图片文件处理
            var fileImg = FileHelp.Set("20.jpg");
            var ms = fileImg.ReadByMemoryStream();

            Image img = Image.FromStream(ms);
            var letterImg = ImageHelper.LetterWatermark("20.jpg", 14, "中华人民共和国", Color.Red, "T");
            Console.WriteLine("{0} 增加水印成功.", letterImg);

            //生成缩略图
            var newImg = ImageHelper.MakeThumbnail(img, 50, 50, ThumbnailModel.Auto);
            newImg.Save("newImg.png", ImageFormat.Png);

            ms.Close();
            #endregion

            #region 文件夹处理
            var allDir = DirectoryHelp.GetAllDirInfo("Log").ToList();

            Console.WriteLine(DirectoryHelp.Combine("aaa", "ddd.txt"));

            foreach (DriveInfo drive in DirectoryHelp.GetAllDrives())
            {
                if (drive.IsReady)
                    Console.WriteLine("类型：{0} 卷标：{1} 名称：{2} 总空间：{3} 剩余空间：{4}", drive.DriveType, drive.VolumeLabel, drive.Name, drive.TotalSize, drive.TotalFreeSpace);
                else
                    Console.WriteLine("类型：{0} 状态：没有准备好", drive.DriveType);
            }
            #endregion
            Console.ReadKey();
        }
    }

    public class MyWrite : TextWriter
    {
        private readonly TextWriter consoleOut = Console.Out;

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }

        public override void Write(char[] buffer, int index, int count)
        {
            var value = new string(buffer, index, count);
            //控制台输出时前面增加时间
            consoleOut.Write(string.Format("{0} {1}", DateTime.Now, value));
        }
    }
}
