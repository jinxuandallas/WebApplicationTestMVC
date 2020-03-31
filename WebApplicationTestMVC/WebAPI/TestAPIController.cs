using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTestMVC.Models;
using WebApplicationTestMVC.Abstract;
//using WebApplicationTestMVC.Concrete;
using WebApplicationTestMVC.App_Start;

namespace WebApplicationTestMVC.WebAPI
{
    public class TestAPIController : BaseApiController
    {
        private IEFProductRepository _EFProductRepository;

        public TestAPIController(IEFProductRepository productRepository)
        {
            _EFProductRepository = productRepository;
        }

        //public TestAPIController()
        //{

        //}

        public List<Product> GetAll()
        {
            return _EFProductRepository.Products.ToList();
        }

        public Product GetOne(int id)
        {
            return _EFProductRepository.Products.Where(p => p.id == id).FirstOrDefault();
        }
    }
}
