using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsManagementSystemWithMVC.Filters;

namespace ProductsManagementSystemWithMVC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HomeController : Controller
    {
        // GET: Admin/Home/index
        public ActionResult Index()
        {
            return View();
        }
    }
}