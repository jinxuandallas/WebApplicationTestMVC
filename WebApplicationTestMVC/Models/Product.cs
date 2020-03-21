using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc.Html;
//using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplicationTestMVC.Models
{
    //[Table("products")]
    public class Product
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }
        public string name { get; set; }
        public string productinfo { get; set; }
    }
}