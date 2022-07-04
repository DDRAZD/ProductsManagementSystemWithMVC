using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Company.DomainModels;
using System.IO;

namespace ProductsManagementSystemWithMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
         //   ModelBinders.Binders.Add(typeof(Student), new CustomBinder());

            //calling the filter config
            FilterConfig.RegisterGlobalFiters(GlobalFilters.Filters);//this argument we are passing here will be recevied in FilterConfig.cs
        }

        protected void Application_Error()
        {
            Exception exec = Server.GetLastError(); //getting the details of the last exception

            //creating a message:
            string s = "Message: " + exec.Message + ", Type: " + exec.GetType().ToString() + ", Source: " + exec.Source;
            StreamWriter sw = File.AppendText(HttpContext.Current.Request.PhysicalApplicationPath + "\\ErrorLog.txt");
            sw.WriteLine(s);
            sw.Close();
            Response.Redirect("Error.html");

        }
    }
}
