using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkTest
{
    public partial class Program
    {
        static void Main(string[] args)
        {

            //直接调用 Program.Partial 子类方法
            Test();

            Console.WriteLine(DateTime.Now.AddDays(1).AddHours(21));
            BenchmarkRunner.Run<TestMd5>();
            Console.ReadLine();
        }
    }

    public class TestMd5
    {
        private string Md5(string password, int bit)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(password));
            StringBuilder tmp = new StringBuilder();
            foreach (byte i in hashedDataBytes)
            {
                tmp.Append(i.ToString("x2"));
            }
            if (bit == 16)
                return tmp.ToString().Substring(8, 16);
            else
            if (bit == 32) return tmp.ToString();//默认情况
            else return string.Empty;
        }
        /// <summary>
        /// Md5 加密
        /// </summary>
        [Benchmark]
        public void TestMD5_32()
        {
            Md5("123456", 32);
        }

        [Benchmark]
        public void TestMD5_16()
        {
            Md5("123456", 16);
        }
    }
}
