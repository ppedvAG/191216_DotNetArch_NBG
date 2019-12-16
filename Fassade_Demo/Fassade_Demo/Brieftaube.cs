using System;
using System.Threading;

namespace Fassade_Demo
{
    class Brieftaube : IBenachrichtigungsSystem
    {
        public void SendeBestätigung()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Brieftaube wird in die Welt entlassen....");
            Thread.Sleep(5500);
            Console.WriteLine("Piep Piep Piep!");
            Console.ResetColor();
        }
    }
}
