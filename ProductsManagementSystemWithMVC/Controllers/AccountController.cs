using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsManagementSystemWithMVC.ViewModels;
using ProductsManagementSystemWithMVC.Models;
using ProductsManagementSystemWithMVC.Identity;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using Microsoft.Owin.Security;

namespace ProductsManagementSystemWithMVC.Controllers
{
    public class AccountController : Controller
    {
       
        public ActionResult Register()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)//validation is valid of all the formats and required fields
            {
                //register
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser() { Email = rvm.Email, UserName=rvm.Username, PasswordHash= passwordHash, City=rvm.City, Country=rvm.Country,  Address=rvm.Address, Birthday = rvm.DataOfBirth, PhoneNumber=rvm.Mobile};

               IdentityResult result =  userManager.Create(user);

                if (result.Succeeded)
                {
                    //role
                    userManager.AddToRole(user.Id, "Customer");

                    //login
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                }

                return RedirectToAction("Register","Account");
            }
            else
            {
                ModelState.AddModelError("My Error", "THe registration was not valid");
                return View();//redirection to the same view but the error msssage from ModelState will be added at the bottom of the view as validation summary is there
            }


            
        }







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