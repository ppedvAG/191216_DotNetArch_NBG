using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekorator_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var lecker = new Käse(new Käse(new Pizza()));

            Console.WriteLine(lecker.Description);
            Console.WriteLine(lecker.Price);

            var leckerMitExtraScharf = new Trüffel(lecker);

            Console.WriteLine(leckerMitExtraScharf.Description);
            Console.WriteLine(leckerMitExtraScharf.Price);

            var leckerMitAnanas = new Käse(new Ananas(leckerMitExtraScharf));

            Console.WriteLine(leckerMitAnanas.Description);
            Console.WriteLine(leckerMitAnanas.Price);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
