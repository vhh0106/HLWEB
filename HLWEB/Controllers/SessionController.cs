using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HLWEB.Common;

namespace HLWEB.Controllers
{
    public class SessionController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (AccountLogin)Session[CommonConstant.ACCOUNT_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Index", Area = "Home" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}