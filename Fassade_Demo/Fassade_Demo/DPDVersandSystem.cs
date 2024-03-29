﻿using System;
using System.Threading;

namespace Fassade_Demo
{
    class DPDVersandSystem : IVersandSystem
    {
        public DPDVersandSystem(IBenachrichtigungsSystem es)
        {
            this.es = es;
        }
        private IBenachrichtigungsSystem es;

        public void VersendeProdukt()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Das Produkt befindet sich auf dem Versandweg");
            Thread.Sleep(15000);
            Console.WriteLine("Empfänger ist nicht zuhause, Paket wird zurück ins Verteilungszentrum geschickt");
            es.SendeBestätigung();
            Console.ResetColor();
        }
    }
}
