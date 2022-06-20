using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductsManagementSystemWithMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, 
                namespaces: new[] { "ProductsManagementSystemWithMVC.Controllers" }
                //the specificed name space will be the default and is added so to avoid confusion between home controller in the admin area vs. outside of it; 
                //most cases will be outside of admin so we default to to the home controller outside of the admin area. When we specify "area="admin"", it will overide that default
            );
        }
    }
}
