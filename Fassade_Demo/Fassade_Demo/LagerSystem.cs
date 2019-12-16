using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fassade_Demo
{
    class LagerSystem
    {
        public bool IstProduktLagernd(int ProduktID)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread.Sleep(1000);
            bool result = false;
            if (ProduktID % 2 == 0)
            {
                Console.WriteLine($"Das Produkt mit der ID {ProduktID} ist lagernd");
                result =  true;
            }
            else
            {
                Console.WriteLine($"Das Produkt mit der ID {ProduktID} ist nicht lagernd");
                result = false;
            }
            Console.ResetColor();
            return result;
        }

        public void ProduktNachbestellen(int ProduktID)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread.Sleep(2500);
            Console.WriteLine($"Das Produkt mit der ID {ProduktID} wurde soeben nachbestellt ....");
            Console.ResetColor();
        }
    }

    class RechnungsSystem
    {
        public bool HatOffeneRechnungen(int KundenID)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
            bool result = false;
            if (KundenID % 5 == 3)
            {
                Console.WriteLine($"Rechnungen sind noch offen, Vorgang wird abgebrochen");
                result = true;
            }
            else
            {
                Console.WriteLine($"Alles OK");
                result = false;
            }
            Console.ResetColor();
            return result;
        }

        public void BezahlvorgangStarten(int KundenID)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Bezahlvorgang wird gestartet....");
            Thread.Sleep(2500);
            Console.WriteLine($"Bezahlvorgang Erfolgreich !");
            Console.ResetColor();
        }
    }

    class EmailSystem
    {
        public void BestätigungsmailVersenden()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Bestätigungsmail wird versendet....");
            Thread.Sleep(500);
            Console.WriteLine("Bestätigungsmail wurde versendet !");
            Console.ResetColor();
        }
    }

    class DHLVersandSystem
    {
        public void VersendeProdukt()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Das Produkt befindet sich auf dem Versandweg");
            Thread.Sleep(10000);
            Console.WriteLine("Empfänger ist nicht zuhause, Paket wird in der Abholstation abgelegt");
            Console.ResetColor();
        }
    }
}
