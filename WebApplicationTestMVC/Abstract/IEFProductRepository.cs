using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTestMVC.Models;

namespace WebApplicationTestMVC.Abstract
{
    public interface IEFProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Account> Accounts { get; }
        void Add(Product product);
    }
}
