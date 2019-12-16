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
}
