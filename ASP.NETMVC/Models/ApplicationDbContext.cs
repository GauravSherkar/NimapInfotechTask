using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NETMVC.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("cs")
        {
                
        }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; }
    }
}