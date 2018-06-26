using DependencyInjection.DependencyLocate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceA = new ServiceClassA();
            var serviceB = new ServiceClassB();
            var clientA = new ClientClass(serviceA);
            clientA.ShowInfo();
            var clientB = new ClientClass(serviceA);
            clientB.ShowInfo();

            var btn = ReflectionFactory.MakeButton();
            Console.WriteLine(btn.ShowInfo());


            Console.ReadLine();
        }
    }
}
