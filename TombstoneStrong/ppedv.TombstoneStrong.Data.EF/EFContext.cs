using Microsoft.EntityFrameworkCore;
using ppedv.TombstoneStrong.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.TombstoneStrong.Data.EF
{
    public class EFContext : DbContext
    {
        public EFContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Für Trainer-Rechner: 
            optionsBuilder.UseSqlServer(@"Server=(localDb)\MSSQLLocalDb;Database=TombstoneStrong;Trusted_Connection=true");
            // Für TN-Rechner : optionsBuilder.UseSqlServer(@"Server=.")
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
