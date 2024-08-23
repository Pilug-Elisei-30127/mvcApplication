using mvcDemo.Controllers;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcDemo.Models
{

    public class SampleContext : DbContext
    {
        public DbSet<Employee> Employee  { get; set; }
        public DbSet<Employee1> Employee1  { get; set; }
        public DbSet<DepartamentController>Departament  { get; set; }

    }

}