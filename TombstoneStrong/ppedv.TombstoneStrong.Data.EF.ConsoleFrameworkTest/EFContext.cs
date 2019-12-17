using ppedv.TombstoneStrong.Domain;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ppedv.TombstoneStrong.Data.EF.ConsoleFrameworkTest
{
    class EFContext : DbContext
    {
        // Trainer:
        //public EFContext() : base(@"Server=(localDb)\MSSQLLocalDb;Database=TombstoneTEST;Trusted_Connection=true")
        public EFContext() : base(@"Server=.;Database=TombstoneStrong;Trusted_Connection=true")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }
    }
}
