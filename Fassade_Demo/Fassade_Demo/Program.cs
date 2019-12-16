using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fassade_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hauptsystem -> In der Webseite der Button "Bestellen"
            Console.OutputEncoding = Encoding.Unicode;

            // Mit Fassade:

            Console.WriteLine("Bitte geben Sie den zu Bestellenden Artikel ein:");
            Console.WriteLine("Artikel 1: GoF - Designpatterns - Buch 49,99€");
            Console.WriteLine("Artikel 2: FireTV Stick 69,99€");
            Console.WriteLine("Artikel 3: Romantische Teelichter - 0,99€");

            int artikelnummer = Convert.ToInt32(Console.ReadLine());

            Amazon alexa = new Amazon();

            alexa.Bestellen(122, artikelnummer);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
