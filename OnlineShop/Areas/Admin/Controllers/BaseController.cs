using OnlineShop.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting (ActionExecutingContext filerContext)
        {
            var seccsion = (UserLogin)Session[CommomConstants.USER_SESSION];
            if(seccsion == null)
            {
                filerContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "index", area = "admin" }));
            }
            base.OnActionExecuting (filerContext);
        }
    }
}