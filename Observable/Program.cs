using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Servabler();
            var client1 = server.Subscribe(new Clienter());
            var client2 = server.Subscribe(new ClientOne());
            client1.Dispose();
            while (true)
            {
                var msg = Console.ReadLine();
                server.Notify(msg);
            }
        }
    }
}
