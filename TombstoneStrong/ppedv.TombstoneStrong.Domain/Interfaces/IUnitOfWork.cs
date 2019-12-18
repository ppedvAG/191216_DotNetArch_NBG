using System;

namespace ppedv.TombstoneStrong.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Type[] SupportedEntities { get; }

        // Feste Implementierung:
        IEmployeeRepository EmployeeRepository { get; }

        // Allgemeine Implementierung
        IUniversalRepository<T> GetRepository<T>() where T : Entity;
        void SaveAll();
    }
}
