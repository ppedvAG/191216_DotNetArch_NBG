using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;

namespace ppedv.TombstoneStrong.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        #region Variante 1:
        //public EFUnitOfWork(EFContext context)
        //{
        //    this.context = context;
        //}
        //private readonly EFContext context; 
        #endregion

        // Variante 2: Context als Singleton
        private readonly object lockObject = new object();
        private EFContext context;
        private EFContext Context
        {
            get
            {
                lock (lockObject)
                {
                    if (context == null)
                        context = new EFContext();
                }
                return context;
            }
        }


        private IEmployeeRepository employeeRepository;
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                lock (lockObject)
                {
                    if (employeeRepository == null)
                        employeeRepository = new EFEmployeeRepository(Context);
                }

                return employeeRepository;
            }
        }

        public IUniversalRepository<T> GetRepository<T>() where T : Entity
        {
            // ToDo: Pro-Variante: Wenn T ein Employee ist -> EmployeeRepository zurückgeben
            // ToDo: Repository-Cache, damit nichts doppelt generiert wird
            return new EFUniversalRepository<T>(Context);
        }

        public void SaveAll()
        {
            if (Context.ChangeTracker.HasChanges())
                Context.SaveChanges();
        }
    }
}
