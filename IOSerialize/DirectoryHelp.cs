using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize
{
    /// <summary>
    /// 文件夹管理
    /// </summary>
    public class DirectoryHelp
    {

        /// <summary>
        /// 检查目录是否存在
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="IsCreate">不存在是否创建</param>
        /// <returns></returns>
        public static bool IsExists(string path, bool IsCreate = true)
        {
            if (!Directory.Exists(path))
            {
                if (!IsCreate)
                {
                    return false;
                }
                Directory.CreateDirectory(path);
                return true;
            }
            return true;
        }

        /// <summary>
        /// 获取所有子录目
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetChildDir(string path)
        {
            return Directory.GetDirectories(path);
        }

        /// <summary>
        /// 获取文件夹信息
        /// </summary>
        /// <returns></returns>
        public static DirectoryInfo GetDirInfo(string path)
        {
            return new DirectoryInfo(path);
        }

        /// <summary>
        /// 获取目录下所有文件
        /// 适合大目录查询
        /// </summary>
        /// <param name="path"></param>
        /// <param name="IsChilds">是否搜索所有子录</param>
        /// <param name="searchPattern">搜索字符串</param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> GetAllFiles(string path, bool IsChilds = true, string searchPattern = "*.*")
        {
            var dirInfo = DirectoryHelp.GetDirInfo(path);
            if (IsChilds)
            {
                return dirInfo.EnumerateFiles(searchPattern, SearchOption.AllDirectories);
            }
            return dirInfo.EnumerateFiles(searchPattern, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// 查看所有目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IEnumerable<DirectoryInfo> GetAllDirInfo(string path)
        {
            var dirInfo = DirectoryHelp.GetDirInfo(path);
            var dirs = Directory.EnumerateDirectories(dirInfo.FullName, "*.*", SearchOption.AllDirectories);  //必需要使用完整物理地址
            foreach (var dir in dirs)
            {
                yield return DirectoryHelp.GetDirInfo(dir);
            }
        }

        /// <summary>
        /// 获取所有磁盘驱动
        /// </summary>
        /// <returns></returns>
        public static DriveInfo[] GetAllDrives()
        {
            return DriveInfo.GetDrives();
        }

        #region Path 路径相关
        /// <summary>
        /// 返回目录名，需要注意路径末尾是否有反斜杠对结果是有影响的
        /// 最后不带 \ ，返回上级目录名如：{ d:\logs\error 返回 logs },{ d:\logs\error\ 返回 error }
        /// </summary>
        /// <param name="path"></param>
        public static string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        /// <summary>
        /// 将返回随机的文件名
        /// </summary>
        public static string GetRandomFileName()
        {
            return Path.GetRandomFileName();
        }

        /// <summary>
        /// 返回文件名
        /// 不含路径和后缀名
        /// </summary>
        public static string GetFileNameWithoutExtension(string file)
        {
            return Path.GetFileNameWithoutExtension("d:\\abc.txt");
        }

        /// <summary>
        /// 将返回禁止在路径中使用的字符
        /// </summary>
        /// <returns></returns>
        public static string GetInvalidPathChars()
        {
            var chars = Path.GetInvalidPathChars();
            return new string(chars);
        }

        /// <summary>
        /// 将返回禁止在文件名中使用的字符
        /// </summary>
        /// <returns></returns>
        public static string GetInvalidFileNameChars()
        {
            var chars = Path.GetInvalidFileNameChars();
            return new string(chars);
        }

        /// <summary>
        /// 合并两个路径
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="file">相对路径</param>
        /// <returns></returns>
        public static string Combine(string path, string file)
        {
            return Path.Combine(path, file);
        }
        #endregion
    }
}
