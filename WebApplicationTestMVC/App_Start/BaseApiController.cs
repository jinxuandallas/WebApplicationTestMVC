using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace WebApplicationTestMVC.App_Start
{
    public class BaseApiController : ApiController
    {
        private object TokenValue { get; set; } = "";
        private object LoginID { get; set; } = "";
        public BaseApiController()
        {
            LoginID = HttpContext.Current.Session["Username"];
            if ( LoginID!= null)
            {
                TokenValue = HttpContext.Current.Session[LoginID.ToString()] ?? "";
                HttpContext.Current.Request.Headers.Add("TokenValue", TokenValue.ToString());
            }
        }
    }
}
