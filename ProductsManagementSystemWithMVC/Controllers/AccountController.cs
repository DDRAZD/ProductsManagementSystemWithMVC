﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsManagementSystemWithMVC.Controllers
{
    public class AccountController : Controller
    {
       [Route("Account/Login")]
        public ActionResult Login(string Username, string Password)
        {

            if (Username == "admin" && Password == "manager")
                return RedirectToAction("Dashboard", "Admin");
            else
                return RedirectToAction("InvalidLogin");//redirects within same controller so no need to specify controller here
            
        }
        [Route("Account/invalidlogin")]
        public ActionResult InvalidLogin()
        {
            return View();
        }
    }
}