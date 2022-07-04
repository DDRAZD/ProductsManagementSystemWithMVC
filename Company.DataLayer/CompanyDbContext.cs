using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//using ProductsManagementSystemWithMVC.Migrations;
using Company.DomainModels;

namespace Company.DataLayer
{
    public class CompanyDbContext:DbContext
    {
        //building the code first tables / dbo
        //the naming conventions is the plural of the class -> "brand" becomes "brands"

        //constructor to build the data base
        public CompanyDbContext() : base("MyConnectionString")
        {
         //   Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
