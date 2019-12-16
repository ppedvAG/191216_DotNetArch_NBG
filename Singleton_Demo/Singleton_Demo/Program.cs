using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Logger().Log("Hallo Welt");
            //new Logger().Log("Demo  1234");
            //new Logger().Log("dadadadadadadaadaaaaa batmaaaan");

            Parallel.For(0, 10_000_000, index =>
             {
                 //Logger log2 = new Logger();
                 //log2.Log($"Batman Nr {index}# meldet sich !!!!");
                 Logger.Instance.Log($"Batman Nr {index}# meldet sich !!!!");
             });



            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
