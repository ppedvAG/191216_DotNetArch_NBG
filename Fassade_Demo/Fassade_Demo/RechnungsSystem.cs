using System;
using System.Threading;

namespace Fassade_Demo
{
    class RechnungsSystem : IRechnungsSystem
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

    class BierdeckelSystem : IRechnungsSystem
    {
        public bool HatOffeneRechnungen(int KundenID)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(500);
            bool result = false;
            if (KundenID % 5 == 3)
            {
                Console.WriteLine($"Bierdeckel ist voll -> ZAHLEN !!!!!");
                result = true;
            }
            else
            {
                Console.WriteLine($"Alles Gut");
                result = false;
            }
            Console.ResetColor();
            return result;
        }

        public void BezahlvorgangStarten(int KundenID)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Bezahlvorgang wird gestartet....");
            Thread.Sleep(500);
            Console.WriteLine($"Bezahlvorgang Erfolgreich !");
            Console.ResetColor();
        }
    }
}
