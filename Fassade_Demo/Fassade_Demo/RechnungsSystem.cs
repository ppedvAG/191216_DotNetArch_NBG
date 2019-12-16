using System;
using System.Threading;

namespace Fassade_Demo
{
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
}
