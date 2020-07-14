using System;
using System.Diagnostics;
using System.IO;
using Topshelf;

namespace BackupsZip
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c =>
            {
                c.Service<BackupsZipControl>();
                c.RunAsLocalSystem();
                c.SetServiceName("BackupsZipServer");
                c.SetDisplayName("BackupsZipServer");
                c.SetDescription("BackupsZipServer");
            });
        }
    }
}
