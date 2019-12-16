using System;
using System.Collections.Generic;

namespace AspektorientiertesProgrammieren_Demo
{
    public class BasicRepository : IRepository
    {
        public void Add<T>(T item)
        {
            Console.WriteLine("Das Element wird hinzugefügt");
        }

        public void Delete<T>(T item)
        {
            Console.WriteLine("Das Element wird gelöscht");
        }

        public IEnumerable<T> GetAll<T>()
        {
            Console.WriteLine("Es werden 50 Elemente zurückgegeben");
            return null;
        }

        public T GetItemByID<T>(int ID)
        {
            Console.WriteLine("Es wird 1 Element zurückgegeben");
            return default;
        }

        public void Update<T>(T item)
        {
            Console.WriteLine("Das Element wird geupdatet");
        }
    }
}
