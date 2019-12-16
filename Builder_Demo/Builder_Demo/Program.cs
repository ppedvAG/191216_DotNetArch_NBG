using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            Schrank ikea1 = Schrank.BaueSchrank()
                                   .MitBöden(2)
                                   .MitTüren(4)
                                   .MitOberfläche(Oberflächenart.Unbehandelt)
                                   .MitKleiderstange(true)
                                   .Erstellen();

            Schrank ikea2 = Schrank.BaueSchrank()
                                   .MitBöden(4)
                                   .MitTüren(2)
                                   .MitOberfläche(Oberflächenart.Lackiert)
                                   .InFarbe("Grün")
                                   .MitKleiderstange(false)
                                   .Erstellen();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
