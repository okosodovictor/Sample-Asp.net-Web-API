using BEAssignment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEAssignment.Data
{
    public class DataEntities : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<Address> Addresses { get; set; }


        public DataEntities() : base("Default")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataEntities, BEAssignment.Data.Migrations.Configuration>("Default"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
