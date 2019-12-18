namespace ppedv.TombstoneStrong.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        // Feste Implementierung:
        IEmployeeRepository EmployeeRepository { get; }

        // Allgemeine Implementierung
        IUniversalRepository<T> GetRepository<T>() where T : Entity;
    }
}
