using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace InitEntity.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<BddContext>(null);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BddContext>());
            base.OnModelCreating(modelBuilder);
        }
    }
}