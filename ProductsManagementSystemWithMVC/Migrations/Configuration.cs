namespace ProductsManagementSystemWithMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsManagementSystemWithMVC.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductsManagementSystemWithMVC.Models.CompanyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Samsung" });
            context.Categories.AddOrUpdate(new Models.Category() { CategoryID = 1, CategoryName = "Appliances" });
            context.Products.AddOrUpdate(new Models.Product() { ProductID = 1, ProductName ="iPhone", AvailabilityStatus="InStock", DOP=DateTime.Now, Active=true, Price=1500, BrandID=1, CategoryID=1});
        }
    }
}
