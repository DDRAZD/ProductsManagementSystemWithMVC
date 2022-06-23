using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using ProductsManagementSystemWithMVC.Identity;

[assembly: OwinStartup(typeof(ProductsManagementSystemWithMVC.Startup))]

namespace ProductsManagementSystemWithMVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType=DefaultAuthenticationTypes.ApplicationCookie, LoginPath=new PathString("/Account/Login") });
            this.CreateRolesAndUsers();//calling it at the first time when the DB is empty (these are deafult roles and users)
        }

        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDbContext();

            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);

            //create admin role
            //if the admin role does not exist, it will create it (so only the first time)
            if(!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);//have to call this to actually create the admin in the database
            }


            //creating the actual admin user (previously, it was just the role)
            if(roleManager.FindByName("admin1") ==null)//if you cannot find any user that is an admin
            {
                var user = new ApplicationUser();
                user.UserName = "admin1";
                user.Email = "admin@gmail.com";
                string userPassword = "admin123";
                var chkUser = userManager.Create(user,userPassword);//creates the user in the database

                if(chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin"); //if the creation of the user was successful, we need to add the user to the role; 
                }

                
            }

            //createa manager role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);//have to call this to actually create the admin in the database
            }

            //create manager user (someone to actually occoupy the role
            if (roleManager.FindByName("manager1") == null)//if you cannot find any user that is a manager
            {
                var user = new ApplicationUser();
                user.UserName = "manager1";
                user.Email = "manager@gmail.com";
                string userPassword = "manager123";
                var chkUser = userManager.Create(user, userPassword);//creates the user in the database

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager"); //if the creation of the user was successful, we need to add the user to the role; 
                }
            }
            //Create Customer Role
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
