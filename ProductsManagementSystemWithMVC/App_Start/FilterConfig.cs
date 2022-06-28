using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsManagementSystemWithMVC.Filters;


//i removed the portion of the namespace that was App_Start
namespace ProductsManagementSystemWithMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFiters(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionFIlter()); //adding my exception filter from the filter folder; will be now applied automatically to all action methods 
        }
    }
}