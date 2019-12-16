using System;
using System.Collections.Generic;

namespace AspektorientiertesProgrammieren_Demo
{
    public class AuthRepository : IRepository
    {
        public AuthRepository(IRepository parent,User currentUser)
        {
            this.parent = parent;
            this.currentUser = currentUser;
        }
        private IRepository parent;
        private User currentUser;

        private void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[{DateTime.Now}]: {message}");
            Console.ResetColor();
        }

        public void Add<T>(T item)
        {
            if (currentUser == User.RegularUser || currentUser == User.Admin)
                parent.Add<T>(item);
            else
                Log("Add ist für den aktuellen User nicht erlaubt !");
        }

        public void Delete<T>(T item)
        {
            if (currentUser == User.Admin)
                parent.Delete<T>(item);
            else
                Log("Delete ist für den aktuellen User nicht erlaubt !");
        }

        public IEnumerable<T> GetAll<T>()
        {
             return parent.GetAll<T>();
        }

        public T GetItemByID<T>(int ID)
        {
            return parent.GetItemByID<T>(ID);
        }

        public void Update<T>(T item)
        {
            if (currentUser == User.Admin || currentUser == User.RegularUser)
                parent.Update<T>(item);
            else
                Log("Update ist für den aktuellen User nicht erlaubt !");
        }
    }
}
