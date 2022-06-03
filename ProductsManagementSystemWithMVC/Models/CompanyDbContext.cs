﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ProductsManagementSystemWithMVC.Models
{
    public class CompanyDbContext:DbContext
    {
        //building the code first tables / dbo
        //the naming conventions is the plural of the class -> "brand" becomes "brands"

        //constructor to build the data base
        public CompanyDbContext():base("MyConnectionString")
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}