using System.Web.Mvc;

namespace OnlineShop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
         
            System.Web.Routing.Route route = context.MapRoute(
              "Default2",
              "Login",
              new { action = "Index", controller = "Login", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Areas.Admin.Controllers" }
          );
        }
    }
}