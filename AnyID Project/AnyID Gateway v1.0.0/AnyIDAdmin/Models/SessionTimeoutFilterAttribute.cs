using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnyIDAdmin.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SessionTimeoutFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            // If the browser session or authentication session has expired...
            if (session.IsNewSession || session[ViewConstant.UserLoginname] == null || session[ViewConstant.Role] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    // For AJAX requests, return result as a simple string, 
                    // and inform calling JavaScript code that a user should be redirected.
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { 
                        { "Controller", "Login" },
                        { "Action", "Logout" }
                    });
                }
                else
                {
                    // For round-trip requests,
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { 
                        { "Controller", "Login" },
                        { "Action", "Index" }
                    });
                }
            }

            base.OnActionExecuting(filterContext);
        }
        //other methods...
    }
}