using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTestMVC.App_Start;
using WebApplicationTestMVC.Abstract;
using WebApplicationTestMVC.Concrete;
using System.Web.Security;
using System.Web;

namespace WebApplicationTestMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseApiController
    {
        private IEFProductRepository _EFProductRepository;
        public LoginController(IEFProductRepository productRepository)
        {
            _EFProductRepository = productRepository;
        }

        [HttpGet]
        public object Login(string uName,string uPassword)
        {
            var user = _EFProductRepository.Accounts.Where(u => u.username == uName && u.password == uPassword).FirstOrDefault();
            if (user == null)
                return Json(new { ret = 0, data = "", msg = "用户名密码错误" });
            FormsAuthenticationTicket token = new FormsAuthenticationTicket(0, uName, DateTime.Now, DateTime.Now.AddHours(12), true, $"{uName}&{uPassword}", FormsAuthentication.FormsCookiePath);
            var _token = FormsAuthentication.Encrypt(token);
            //LoginID = uName;
            //TokenValue = _token;
            HttpContext.Current.Session["Username"] = uName;
            HttpContext.Current.Session[uName] = _token;
            return Json(new { ret = 1, data = _token, msg = "登录成功！" });
        }
    }
}
