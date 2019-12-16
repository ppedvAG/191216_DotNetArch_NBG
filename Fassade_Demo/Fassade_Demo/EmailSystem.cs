using System;
using System.Threading;

namespace Fassade_Demo
{
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
}
