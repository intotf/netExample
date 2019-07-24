using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Topshelf;

namespace FileSync
{
    class Program
    {
        static void Main(string[] args)
        {

            HostFactory.Run(c =>
            {
                c.Service<FileSyncControl>();
                c.RunAsLocalSystem();
                c.SetServiceName("FileSyncServer");
                c.SetDisplayName("FileSyncServer");
                c.SetDescription("FileSyncServer");
            });
        }

    }
}
