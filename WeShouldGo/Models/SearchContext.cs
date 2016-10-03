using WeShouldGo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeShouldGo.Models
{
    public class SearchContext : DbContext
    {
        public SearchContext() :
            base("DefaultConnection")
        {

        }

        public DbSet<Search> Search { get; set; }
        public DbSet<ServiceConnections> ServiceConnections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
