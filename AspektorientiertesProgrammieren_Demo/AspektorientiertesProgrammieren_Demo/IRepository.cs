using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektorientiertesProgrammieren_Demo
{
    public interface IRepository // Definition aller Datenbank-Befehle (Entspricht IComponent)
    {
        // CRUD -> Create/Read/Update/Delete

        void Add<T>(T item);
        void Delete<T>(T item);
        void Update<T>(T item);
        T GetItemByID<T>(int ID);
        IEnumerable<T> GetAll<T>();
    }
}
