using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusinessLayer.Models
{
    public class DataBaseconnection: DbContext
    {
        public DataBaseconnection(): base("DataBaseconnection")
        {
            Database.SetInitializer<DataBaseconnection>(null);  
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}