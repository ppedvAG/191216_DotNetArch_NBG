using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurant michisBeisl = new Restaurant();

            var leckerJetzt = michisBeisl.GibEssen();
            var leckerSpäter = michisBeisl.GibEssen(new DateTime(1848,3,12,18,33,59));

            leckerSpäter.Beschreibung();
            

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
