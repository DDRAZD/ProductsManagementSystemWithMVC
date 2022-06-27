using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ProductsManagementSystemWithMVC.Filters
{
    public class CustomerAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole("Customer")==false)
            {
                filterContext.Result =new HttpUnauthorizedResult();
            }
        }
    }
}