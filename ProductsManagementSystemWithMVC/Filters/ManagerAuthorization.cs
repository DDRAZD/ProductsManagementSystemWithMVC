using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ProductsManagementSystemWithMVC.Filters
{
    public class ManagerAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.User.IsInRole("Manager")==false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}