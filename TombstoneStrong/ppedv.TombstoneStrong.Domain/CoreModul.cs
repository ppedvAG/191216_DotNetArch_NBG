using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.TombstoneStrong.Domain
{
    public abstract class CoreModul<T> : ICoreModul<T> where T : Entity
    {
        // Benötigt das IUnitOfWork und reicht Befehle durch
        public CoreModul(IUnitOfWork UoW)
        {
            this.UoW = UoW;
        }
        protected readonly IUnitOfWork UoW; // Theoretisch auch die Möglichkeit, auf andere Datentypen zuzugreifen

        protected IUniversalRepository<T> GetRepository() => UoW.GetRepository<T>();

        public abstract void Add(T item);
        public abstract void Delete(T item);
        public abstract void Update(T item);
        public abstract T GetByID(int ID);
        public abstract IEnumerable<T> GetAll();
    }
}