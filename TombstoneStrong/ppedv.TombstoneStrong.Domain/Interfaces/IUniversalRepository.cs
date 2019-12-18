using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.TombstoneStrong.Domain.Interfaces
{
    public interface IUniversalRepository<T>  where T : Entity
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T GetByID(int ID);
        IEnumerable<T> GetAll();
        IQueryable<T> Query() ; // Für LINQ auf dem DBSet
    }
}
