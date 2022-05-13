using System;
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
        /// <summary>
        /// this is from the Udemy assignment 2 on razors; recevices an amount and breaks it down to denomiations
        /// Consider, you have denominations of 1000, 500, 100, 50, 10, 5, and 1.
        /// </summary>
        /// <param name="Amount">received from the user from the url</param>
        /// <returns>the view that will have razor block in it</returns>
        public ActionResult IndexAssignment(int Amount)
        {
          /*  List<int> numbersList = new List<int>();
            int numberToAdd = 0;
            numberToAdd = Amount % 10;

            if (Amount % 10 >= 5)
            {
                numbersList.Add(numberToAdd % 5); // adds the 1s
                numbersList.Add(1); // the only case you will actually add denomination of 5
            }
            else
            {
                numbersList.Add(numberToAdd); // adds the 1s
                numbersList.Add(0);//adds denomination of 5 as 0

            }

            Amount = Amount / 10;//removes the 1st 
            numberToAdd = Amount % 10;//gets the 10s
            numbersList.Add(numberToAdd);//adds the 10
            Amount = Amount / 10; //removes the 10st
            numberToAdd = Amount % 10;//gets the 100s
            if (Amount % 10 >= 5)
            {
                numbersList.Add(numberToAdd % 5); // adds the 100s
                numbersList.Add(1); // the only case you will actually add denomination of 500
            }
            else
            {
                numbersList.Add(numberToAdd); // adds the 100s
                numbersList.Add(0);//adds denomination of 5 as 0

            }

            Amount = Amount / 10; //removes the 100
            numbersList.Add(Amount);//adds the 1000s


            // ViewBag.Numbers = numbersList;*/
            ViewBag.Number = Amount;

            return View();
        }
    }
}