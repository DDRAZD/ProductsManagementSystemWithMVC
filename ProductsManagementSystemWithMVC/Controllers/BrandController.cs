using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsManagementSystemWithMVC.Models;

namespace ProductsManagementSystemWithMVC.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand/index
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}