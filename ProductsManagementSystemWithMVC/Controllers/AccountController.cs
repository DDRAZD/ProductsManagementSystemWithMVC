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
        //GET request
        public ActionResult Register()
        {
            return View();
        }

        //Post request, after form submission
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
                var user = new ApplicationUser() { Email = rvm.Email, UserName = rvm.Username, PasswordHash = passwordHash, City = rvm.City, Country = rvm.Country, Address = rvm.Address, Birthday = rvm.DataOfBirth, PhoneNumber = rvm.Mobile };

                IdentityResult result = userManager.Create(user);

                if (result.Succeeded)
                {
                    //role
                    userManager.AddToRole(user.Id, "Customer");

                    //login
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                }

                return RedirectToAction("Register", "Account");
            }
            else
            {
                ModelState.AddModelError("My Error", "THe registration was not valid");
                return View();//redirection to the same view but the error msssage from ModelState will be added at the bottom of the view as validation summary is there
            }



        }






        //Get Request
        //   [Route("Account/Login")] commenting it out as it seems to overide the post request from the form
        public ActionResult Login()
        {

            return View();

        }

        //Post request
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            //login
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);
            if (user != null)
            {
                //login
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (userManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "Home", new {area="Manager"});
                }
                else
                {
                    return RedirectToAction("Index", "Home");//not admin, nor manager, goes to root as usual
                }
            }
            else
            {
                ModelState.AddModelError("myerror", "Invalid username or password");
                return View();
            }

            /*
            var user = userManager.Find(lvm.Username, lvm.Password);
            if (user != null) //successufl login
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
               
                if(userManager.IsInRole(user.Id,"Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                { 
                    return RedirectToAction("Index", "Home"); 
                }
               
            }
            else //matching user is not found in the database
            {
                ModelState.AddModelError("myerror", "Invalid username or password");//this will be sent to the view and displayed in the validation summary of the view
                return View();
            }*/


        }

        public ActionResult Logout()
        {
            //creating an authentication manager which is responsbile to login and out (like before):
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("index", "home");
        }

        public ActionResult MyProfile()
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser=  userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }



            [Route("Account/invalidlogin")]
        public ActionResult InvalidLogin()
        {
            return View();
        }
    }
}