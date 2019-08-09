using System;

namespace DeveloperMode
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = modelResult(120);
            ImplicitResult<int> model = 100;    //隐式转换
            ExplicitResult<int> a = (ExplicitResult<int>)100; //显示转换

            Console.WriteLine(s.Data);
            Console.WriteLine("Hello World!");
        }

        static ImplicitResult<int> modelResult(int data)
        {
            return data;
        }
    }
}
