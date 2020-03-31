using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Text;

namespace WebApplicationTestMVC.App_Start
{
    public class TokenCheckFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //var content = actionContext.Request.Properties["MS_HttpContext"] as HttpContextBase;
            var token = HttpContext.Current.Request.Headers["TokenValue"] ?? "";
            if (!string.IsNullOrEmpty(token))
            {
                if (ValidateTicket(token))
                    base.IsAuthorized(actionContext);
                else
                    HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous)
                    base.OnAuthorization(actionContext);
                else
                    HandleUnauthorizedRequest(actionContext);
            }
        }

        private bool ValidateTicket(string encryptToken)
        {
            var strTicket = FormsAuthentication.Decrypt(encryptToken).UserData;
            var index = strTicket.IndexOf("&");
            string userName = strTicket.Substring(0, index);
            string password = strTicket.Substring(index + 1);
            var token = HttpContext.Current.Session[userName];
            if (token == null)
                return false;
            if (token.ToString() == encryptToken)
                return true;
            return false;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);

            var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Forbidden;
            var content = new
            {
                success = false,
                errs = new[] { "服务端拒绝访问：你没有权限?，或者掉线了?" }
            };
            response.Content = new StringContent(Json.Encode(content), Encoding.UTF8, "application/json");
        }
    }
}