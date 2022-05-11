﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsManagementSystemWithMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetEmpName(int Empid)
        {
            var employees = new[]
            {
                new {Empid = 1, EmpName = "Scott", Salary = 8000},
                new {Empid = 2, EmpName ="Smith", Salary =90000},
                new {Empid = 3, EmpName ="Allen", Salary = 888787}
            };
            string matchEmpName = null;

            foreach (var emp in employees)
            {
                if (emp.Empid == Empid) matchEmpName = emp.EmpName;
            }
            //return new ContentResult() { Content = matchEmpName, ContentType = "text/plain" };
            return Content(matchEmpName, "text/plain");
        }


        public ActionResult GetPaySlip(int Empid)
        {
            string fileNmae = "~/PaySlip"+Empid+".pdf";
            return File(fileNmae, "application/pdf");

        }
    }
}