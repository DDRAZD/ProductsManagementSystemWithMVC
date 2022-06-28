using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ProductsManagementSystemWithMVC.Models;

namespace ProductsManagementSystemWithMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Student), new CustomBinder());

            //calling the filter config
            FilterConfig.RegisterGlobalFiters(GlobalFilters.Filters);//this argument we are passing here will be recevied in FilterConfig.cs
        }
    }
}
