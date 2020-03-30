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
        public string TokenValue { get; set; } = "";
        public string LoginID { get; set; } = "";
        public BaseApiController()
        {
            TokenValue = HttpContext.Current.Session[LoginID].ToString() ?? "";
            HttpContext.Current.Request.Headers.Add("TokenValue", TokenValue);
        }
    }
}
