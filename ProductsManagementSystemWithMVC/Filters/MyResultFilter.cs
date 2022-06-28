using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsManagementSystemWithMVC.Filters
{
    public class MyResultFilter : FilterAttribute, IResultFilter
    {
        //this one makes final changes to the result
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //left blank on purpose
        }

        //done first:
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.NoOfVisionsofTheDay = 90;// setting value for an arbitrary variable
        }
    }
}