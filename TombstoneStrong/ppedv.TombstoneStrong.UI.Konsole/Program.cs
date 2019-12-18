using ppedv.TombstoneStrong.Data.EF;
using ppedv.TombstoneStrong.Data.XML;
using ppedv.TombstoneStrong.Domain;
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
            Core core = new Core(new XMLUnitOfWork(),new EFUnitOfWork());

            if(core.IsEmpty<Employee>())
            {
                core.GenerateTestData(); // für XML UND EF
            }
            User currentUser = User.CanDelete;
            var empModul = core.CreateModul<Employee>()
                               .WithAuthentification(currentUser)
                               .LogsExceptionsInto(message => 
                               {
                                   Console.ForegroundColor = ConsoleColor.Red;
                                   Console.WriteLine(message);
                                   Console.ResetColor();
                               })
                               .Build();

            IEnumerable<Employee> allEmployees = empModul.GetAll();
            if (allEmployees is null)
            {
                Console.WriteLine("Programm wird beendet");
                Console.ReadKey();
                return;
            }

            foreach (var emp in allEmployees ?? Enumerable.Empty<Employee>())
            {
                Console.WriteLine($"{emp.ID}: {emp.Name} - Abteilung: {emp.Department}");
            }

            Console.WriteLine("Bitte geben Sie die ID des Mitarbeiters an, dessen Zeiterfassung Sie sehen wollen:");
            int id = Convert.ToInt32(Console.ReadLine());

            var allTimeSheets = (core.Modul<TimeSheet>() as TimeSheetModul).GetAllTimeSheetsForEmployee(allEmployees.First(x => x.ID == id));

            foreach (var timeSheet in allTimeSheets)
            {
                Console.WriteLine($"Von {timeSheet.Start.ToLongDateString()} bis {timeSheet.End.ToLongDateString()}");
                Console.WriteLine($"Gesamtzeit: { timeSheet.End - timeSheet.Start}");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
