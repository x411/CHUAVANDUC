using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHUAVANDUC
{
    public class CustomAuthAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }

        [HandleError(View = "Shared/Error")]
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            var user = ctx.HttpContext.User;

            if (!user.IsInRole(Role))
            {
                ctx.Result = new HttpUnauthorizedResult();
            }
        }
    }

    public class CustomAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                this.HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                //filterContext.Result = new RedirectToRouteResult(
                //new RouteValueDictionary 
                //{ 
                //    { "controller", "Error" }, 
                //    { "action", "Index" } 
                //});
                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.HttpContext.Response.StatusDescription = "You don't have access to this page.";
            }
        }

    }//end-class
}