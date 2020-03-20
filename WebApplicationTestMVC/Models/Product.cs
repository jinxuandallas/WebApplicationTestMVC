using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplicationTestMVC.Models
{
    //[Table("products")]
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string productinfo { get; set; }
    }
}