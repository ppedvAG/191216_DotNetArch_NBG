using ppedv.TombstoneStrong.Domain;
using System.Data.Entity;

namespace ppedv.TombstoneStrong.Data.EF.ConsoleFrameworkTest
{
    class EFContext : DbContext
    {
        // Trainer:
        //public EFContext() : base(@"Server=(localDb)\MSSQLLocalDb;Database=TombstoneTEST;Trusted_Connection=true")
        public EFContext() : base(@"Server=.;Database=TombstoneTEST;Trusted_Connection=true")
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }
    }
}
