using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using mvcAPP.Models;

namespace mvcAPP.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(): base("name=appConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());
        }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}