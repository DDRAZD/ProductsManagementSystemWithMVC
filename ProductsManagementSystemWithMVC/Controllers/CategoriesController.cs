using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsManagementSystemWithMVC.Models;


namespace ProductsManagementSystemWithMVC.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories/Index
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities db =new EFDBFirstDatabaseEntities();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}