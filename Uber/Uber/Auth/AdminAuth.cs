using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Uber.Auth
{
    public class AdminAuthAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!IsAuthorized(actionContext))
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }

        protected virtual bool IsAuthorized(HttpActionContext actionContext)
        {
            var cookie = HttpContext.Current.Request.Cookies["UserRole"];
            return cookie != null && (cookie.Value == "admin" || cookie.Value == "User"); // Adjust roles as needed
        }

        protected virtual void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Unauthorized" });
        }
    }
}
