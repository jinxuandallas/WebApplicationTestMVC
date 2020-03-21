using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTestMVC.Concrete;
using WebApplicationTestMVC.Models;

namespace WebApplicationTestMVC.Controllers
{
    public class TestController : Controller
    {
        private EFProductRepository productRepository;
        public TestController()
        {
            productRepository = new EFProductRepository();
        }
        // GET: Test
        public ActionResult Index()
        {
            //using (EFDbContext c = new EFDbContext())
            //{

            //    Product p = new Product();
            //    p.id = 5;
            //    p.name = "dd";
            //    p.productinfo = "xx";
            //    c.products.Add(p);
            //}
            return View(productRepository.Products);
        }

        public ActionResult Add()
        {
            ViewBag.Succeed = false;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            productRepository.Add(product);
            ViewBag.Succeed = true;
            return RedirectToAction("Index");
        }
    }
}