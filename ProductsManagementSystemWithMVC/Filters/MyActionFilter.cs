using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsManagementSystemWithMVC.Filters
{
    public class MyActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.NoOfVisionsofTheDay = 50; //changing the value of the arbitrary value to be the most rcently assigned
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.NoOfVisionsofTheDay = 70; //setting a new variable inside viewbag - this will be done first

        }
    }
}