using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationTestMVC.Models;

namespace WebApplicationTestMVC.Concrete
{
    public class EFProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }
    }
}