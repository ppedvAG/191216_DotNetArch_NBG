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

            LagerSystem ls = new LagerSystem();
            RechnungsSystem rs = new RechnungsSystem();
            DHLVersandSystem vs = new DHLVersandSystem();
            EmailSystem es = new EmailSystem();



            // Ohne Fassade:

            Console.WriteLine("Bitte geben Sie den zu Bestellenden Artikel ein:");
            Console.WriteLine("Artikel 1: GoF - Designpatterns - Buch 49,99€");
            Console.WriteLine("Artikel 2: FireTV Stick 69,99€");
            Console.WriteLine("Artikel 3: Romantische Teelichter - 0,99€");

            int artikelnummer = Convert.ToInt32(Console.ReadLine());

            if(rs.HatOffeneRechnungen(122) == false)
            {
                if(ls.IstProduktLagernd(artikelnummer))
                {
                    rs.BezahlvorgangStarten(122);
                    es.BestätigungsmailVersenden();
                    vs.VersendeProdukt();
                }
                else
                {
                    Console.WriteLine("Das Produkt ist in ihrem Land nicht verfügbar");
                }
            }
            else
                Console.WriteLine("BEZAHL ERST DEINEN DECKEL !!!!!!!");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
