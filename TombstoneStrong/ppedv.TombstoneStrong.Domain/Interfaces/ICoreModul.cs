using System.Collections.Generic;

namespace ppedv.TombstoneStrong.Domain.Interfaces
{
    public interface ICoreModul<T> where T : Entity
    {
        void Add(T item);
        void Delete(T item);
        IEnumerable<T> GetAll();
        T GetByID(int ID);
        void Update(T item);
    }
}