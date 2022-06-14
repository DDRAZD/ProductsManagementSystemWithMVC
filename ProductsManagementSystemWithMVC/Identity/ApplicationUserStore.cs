using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProductsManagementSystemWithMVC.Identity
{
    public class ApplicationUserStore:UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext dbContext):base(dbContext)
        {

        }
    }
}