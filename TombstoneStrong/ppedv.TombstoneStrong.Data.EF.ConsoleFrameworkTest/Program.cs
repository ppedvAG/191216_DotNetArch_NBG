using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TombstoneStrong.Data.EF.ConsoleFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EFContext context = new EFContext();

            var item = context.Employee.FirstOrDefault(x => x.ID == 1);
            Console.WriteLine(item?.Name ?? "Kein Item gefunden");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
