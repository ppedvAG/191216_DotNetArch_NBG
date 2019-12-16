using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Observer_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Heizung h1 = new Heizung();
            Ventilator v1 = new Ventilator();

            TempSensor sensor = new TempSensor(20, 50);

            Observer.Subscribe(v1, "Heiß", v1.VentilatorAufdrehen);
            Observer.Subscribe(h1, "Kalt", h1.HeizungAufdrehen);

            for (int i = 0; i < 60; i++)
            {
                if (i == 10)
                    Observer.Unsubscribe(h1, "Kalt"); // Zur Laufzeit entfernen
                Thread.Sleep(250);
                sensor.CurrentTemp = i;
                Console.WriteLine($"Aktuelle Temp: {sensor.CurrentTemp}");
            }


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
