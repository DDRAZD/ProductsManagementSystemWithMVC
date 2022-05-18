using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsManagementSystemWithMVC.Models;

namespace ProductsManagementSystemWithMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(CustomBinder))] Student stu)
        {
            return View();
        }
    }
}