using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektorientiertesProgrammieren_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repo = new AuthRepository(
                                    new LoggerRepository(
                                        new BasicRepository()),
                               User.RegularUser);

            /* Alternative: Builder
             * var repo = Repository.BuildRepository()
             *                      .WithLogger()
             *                      .WithAuth()
             *                      .WithWriteAccess()
             *                      .Create();
             */

            repo.Add<Person>(null);
            repo.Update<Person>(null);
            repo.GetItemByID<Person>(12);
            repo.GetAll<Person>();
            repo.Delete<Person>(null);



            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
