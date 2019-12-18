using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.TombstoneStrong.Data.EF
{
    public class EFUniversalRepository<T> : IUniversalRepository<T> where T : Entity
    {
        public EFUniversalRepository(EFContext context)
        {
            this.context = context;
        }
        protected readonly EFContext context;

        public void Add(T item)
        {
            context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToArray();
        }

        public T GetByID(int ID)
        {
            return context.Set<T>().Find(ID);
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }

        public void Update(T item)
        {
            context.Set<T>().Update(item);
        }
    }
}
