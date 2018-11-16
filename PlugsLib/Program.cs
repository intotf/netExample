using PlugsLib.plugs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugsLib
{

    
    public class serve : IObservable<string>
    {
        public List<IObserver<string>> list = new List<IObserver<string>>();

        public IDisposable Subscribe(IObserver<string> observer)
        {
            return new disposa(observer, list);
        }

        public void Notify(string message)
        {
            this.list.ForEach(item => item.OnNext(message));
        }
    }

    public class disposa : IDisposable
    {
        public List<IObserver<string>> list;

        public IObserver<string> s;

        public disposa(IObserver<string> s, List<IObserver<string>> list)
        {
            this.list = list;
            this.s = s;
        }

        public void Dispose()
        {
            list.Remove(s);
        }
    }

    public class clinet : IObserver<string>
    {

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            Console.WriteLine(value);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var server = new serve();
            var c = server.Subscribe(new clinet());
            c.Dispose();
            foreach (var item in server.list)
            {
                item.OnNext("22");
            }

            var plugs = new AcsPlug();
            plugs.LoadPlugs<PlugOne>();
            plugs.LoadPlugs<PlugTwo>();
            plugs.Start();
            Console.ReadKey();
        }
    }
}
