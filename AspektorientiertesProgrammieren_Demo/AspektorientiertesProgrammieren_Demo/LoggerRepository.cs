using System;
using System.Collections.Generic;

namespace AspektorientiertesProgrammieren_Demo
{
    public class LoggerRepository : IRepository // Dekorator
    {
        public LoggerRepository(IRepository parent)
        {
            this.parent = parent;
        }
        private IRepository parent;

        private void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now}]: {message}");
            Console.ResetColor();
        }

        public void Add<T>(T item)
        {
            Log("Vor dem Add");
            parent.Add<T>(item); // Infos durchreichen an Parent
            Log("Nach dem Add");
        }

        public void Delete<T>(T item)
        {
            Log("Vor dem Delete");
            parent.Delete<T>(item); // Infos durchreichen an Parent
            Log("Nach dem Delete");
        }

        public IEnumerable<T> GetAll<T>()
        {
            Log("Vor dem GetAll");
            var result = parent.GetAll<T>(); // Infos durchreichen an Parent
            Log("Nach dem GetAll");
            return result;
        }

        public T GetItemByID<T>(int ID)
        {
            Log("Vor dem GetByID");
            var result = parent.GetItemByID<T>(ID); // Infos durchreichen an Parent
            Log("Nach dem GetByID");
            return result;
        }

        public void Update<T>(T item)
        {
            Log("Vor dem Update");
            parent.Update<T>(item); // Infos durchreichen an Parent
            Log("Nach dem Update");
        }
    }
}
