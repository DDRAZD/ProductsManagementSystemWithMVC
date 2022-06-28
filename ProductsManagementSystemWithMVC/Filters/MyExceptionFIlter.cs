using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; // allows us to store the exception as a log in a file

namespace ProductsManagementSystemWithMVC.Filters
{
    public class MyExceptionFIlter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string s = "Message: " + filterContext.Exception.Message + " , Type" + filterContext.Exception.GetType().ToString() + " , Source: " + filterContext.Exception.Source;
         StreamWriter sw =   File.AppendText(filterContext.RequestContext.HttpContext.Request.PhysicalApplicationPath + "\\ErrorLog.txt");
            //write content into the newly created log file:
            sw.WriteLine(s);
            sw.Close();

            filterContext.ExceptionHandled = true;
            //redirect post error:
            filterContext.Result = new RedirectResult("~/Error.html");//will need to create this page (global view)

        }
    }
}