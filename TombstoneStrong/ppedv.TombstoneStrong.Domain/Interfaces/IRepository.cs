using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.TombstoneStrong.Domain.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T item) where T : Entity;
        void Delete<T>(T item) where T : Entity;
        void Update<T>(T item) where T : Entity;
        T GetByID<T>(int ID) where T : Entity;
        IEnumerable<T> GetAll<T>() where T : Entity;
        IQueryable<T> Query<T>() where T : Entity; // Für LINQ auf dem DBSet
        void Save();
    }
}
