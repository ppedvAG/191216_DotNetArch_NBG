using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Aufgabenliste einkaufen = new Aufgabenliste();
            einkaufen.Unteraufgaben.Add(new Einzelaufgabe { Person = "Michi Z", Titel = "Äpfel", Dauer = TimeSpan.FromMinutes(3), IstErledigt = false });
            einkaufen.Unteraufgaben.Add(new Einzelaufgabe { Person = "Michi Z", Titel = "Birnen", Dauer = TimeSpan.FromMinutes(1), IstErledigt = false });
            einkaufen.Unteraufgaben.Add(new Einzelaufgabe { Person = "Michi Z", Titel = "Bananen", Dauer = TimeSpan.FromMinutes(5), IstErledigt = true });

            Aufgabenliste haushalt = new Aufgabenliste();
            haushalt.Unteraufgaben.Add(new Einzelaufgabe { Person = "Michi Z", Titel = "Staubsaugen", Dauer = TimeSpan.FromMinutes(15), IstErledigt = true });
            haushalt.Unteraufgaben.Add(new Einzelaufgabe { Person = "Michi Z", Titel = "Kochen", Dauer = TimeSpan.FromMinutes(30), IstErledigt = true });
            haushalt.Unteraufgaben.Add(new Einzelaufgabe { Person = "Hund", Titel = "Gassi gehen", Dauer = TimeSpan.FromMinutes(60), IstErledigt = true });

            Aufgabenliste tagesaufgaben = new Aufgabenliste();
            tagesaufgaben.Unteraufgaben.Add(einkaufen);
            tagesaufgaben.Unteraufgaben.Add(haushalt);
            tagesaufgaben.Unteraufgaben.Add(new Einzelaufgabe { Person = "Hund", Titel = "Wild durch die Wohnung rennen", Dauer = TimeSpan.FromMinutes(120), IstErledigt = true });


            if(tagesaufgaben.IstErledigt)
            {
                Console.WriteLine("Alle Tagesaufgaben sind erledigt");
            }

            if(haushalt.IstErledigt)
            {
                Console.WriteLine("Zuhause gibts nichts mehr zu tun :) ");
                Console.WriteLine(haushalt.Dauer.TotalMinutes);
            }

            Console.WriteLine(tagesaufgaben.Dauer.TotalMinutes);


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
