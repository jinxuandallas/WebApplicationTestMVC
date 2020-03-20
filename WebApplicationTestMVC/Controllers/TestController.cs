using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTestMVC.Concrete;

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
            return View(productRepository.Products);
        }
    }
}