using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.TombstoneStrong.Data.EF
{
    public class EFRepository : IRepository
    {
        public EFRepository(EFContext context)
        {
            this.context = context;
        }
        private readonly EFContext context;

        public void Add<T>(T item) where T : Entity
        {
            context.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : Entity
        {
            context.Set<T>().Remove(item);
        }

        public void Update<T>(T item) where T : Entity
        {
            context.Set<T>().Update(item);
        }

        public T GetByID<T>(int ID) where T : Entity
        {
            return context.Set<T>().Find(ID);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToArray();
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return context.Set<T>();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
