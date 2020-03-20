using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplicationTestMVC.Models;

namespace WebApplicationTestMVC.Concrete
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class EFDbContext:DbContext
    {
        public EFDbContext() : base("Name=MySql")
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}