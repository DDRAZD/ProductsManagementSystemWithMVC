using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsManagementSystemWithMVC.Models;
using ProductsManagementSystemWithMVC.Filters;

namespace ProductsManagementSystemWithMVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home/Index")]
        [Route("")]
        [MyActionFilter]
        [MyResultFilter]
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
            ViewBag.TollFree = "6767676766767";
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

        public ActionResult EmpFacebookPage(int EmpId)
        {
            var employees = new[]
            {
                new {Empid = 1, EmpName = "Scott", Salary = 8000},
                new {Empid = 2, EmpName ="Smith", Salary =90000},
                new {Empid = 3, EmpName ="Allen", Salary = 888787}
            };

            string fbUrl = null;
            foreach(var emp in employees)
            {
                if(emp.Empid==EmpId) fbUrl =  "http://www.facebook.com/emp" + EmpId; 
            }

            if (fbUrl == null) return Content("Invalid EmpId", "text/plain");
            else return Redirect(fbUrl);

        }

        public ActionResult StudentDetails()
        {
            ViewBag.StudentName = "Scott";
            ViewBag.StudentId = 101;
            ViewBag.Marks = 20;
            ViewBag.NoOfSemesters = 6;
            ViewBag.Subjects = new List<string>() { "Math", "Physics", "Chemistry" };
            return View();
        }
       
        public ActionResult IndexAssignment(int Amount)
        {
          
       
            ViewBag.Number = Amount;

            return View();
        }

        public ActionResult RequestExample()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalApplicationPath = Request.PhysicalApplicationPath;
            ViewBag.Path = Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString;
            ViewBag.Header = Request.Headers["Accept"];
            ViewBag.Method = Request.HttpMethod;

            return View();
        }

        public ActionResult ResponseExample()
        {
            Response.Write("Hello from response example text");
            Response.ContentType = "text/html";
            Response.Headers["Server"] = "My Server";
            Response.StatusCode = 500;
            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserRegistration(User user)
        {
            if (ModelState.IsValid)
            {
                return Content("Valid");
            }
            else
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList().Select(error => error.ErrorMessage);  //convert list of error objects into a List<string>
                return Content(string.Join(". ", allErrors));
            }
            
        }
    }
}