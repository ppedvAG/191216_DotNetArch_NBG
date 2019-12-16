using System;
using System.Threading;

namespace Fassade_Demo
{
    class EmailSystem : IBenachrichtigungsSystem
    {
        public void SendeBestätigung()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Bestätigungsmail wird versendet....");
            Thread.Sleep(500);
            Console.WriteLine("Bestätigungsmail wurde versendet !");
            Console.ResetColor();
        }
    }
}
