using ppedv.TombstoneStrong.Data.EF;
using ppedv.TombstoneStrong.Data.XML;
using ppedv.TombstoneStrong.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TombstoneStrong.UI.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Core core = new Core(new XMLUnitOfWork());

            // Für EFs
            // if (core.IsTimeSheetEmpty())
            //     core.GenerateTestData();

            var allEmployees = core.GetAllEmployees();

            if(allEmployees.Count() == 0)
            {
                core.GenerateTestEmployees(); // für XML
                allEmployees = core.GetAllEmployees();
            }

            foreach (var emp in allEmployees)
            {
                Console.WriteLine($"{emp.ID}: {emp.Name} - Abteilung: {emp.Department}");
            }


            //Console.WriteLine("Bitte geben Sie die ID des Mitarbeiters an, dessen Zeiterfassung Sie sehen wollen:");
            //int id = Convert.ToInt32(Console.ReadLine());

            //var allTimeSheets = core.GetAllTimeSheetsForEmployee(allEmployees.First(x => x.ID == id));

            //foreach (var timeSheet in allTimeSheets)
            //{
            //    Console.WriteLine($"Von {timeSheet.Start.ToLongDateString()} bis {timeSheet.End.ToLongDateString()}");
            //    Console.WriteLine($"Gesamtzeit: { timeSheet.End - timeSheet.Start}");
            //}

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
