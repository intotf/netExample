using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class ServiceClassB : IServiceClass
    {
        public String ServiceInfo()
        {
            return "我是ServceClassB";
        }
    }
}
