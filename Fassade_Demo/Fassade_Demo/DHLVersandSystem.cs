using System;
using System.Threading;

namespace Fassade_Demo
{
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
