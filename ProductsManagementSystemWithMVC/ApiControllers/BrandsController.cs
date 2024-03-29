﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Company.DomainModels;
using Company.DataLayer;

namespace ProductsManagementSystemWithMVC.ApiControllers
{
    [Authorize(Roles = "Admin")]
    public class BrandsController : ApiController
    {
        public List<Brand> GetBrands()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Brand> brands = new List<Brand>();
            brands = db.Brands.ToList();
            return brands;
        }

        public Brand GetBrandsByID(long BrandID)
        {
            CompanyDbContext db = new CompanyDbContext();
            Brand brand = db.Brands.FirstOrDefault(b => b.BrandID == BrandID);
            
            return brand;
        }

        
        public void PostBrand(Brand newBrand)
        {
            CompanyDbContext db = new CompanyDbContext();
            Brand brandToInsert = new Brand();
            db.Brands.Add(newBrand);
            db.SaveChanges();
        }

        public void PutBrand(Brand brand)
        {
            CompanyDbContext db = new CompanyDbContext();
          Brand brandToEdit =   db.Brands.Where(y=>y.BrandID==brand.BrandID).FirstOrDefault();
            brandToEdit.BrandName = brand.BrandName;
            db.SaveChanges();
        }

        public void DeleteBrand(long BrandID)
        {
            CompanyDbContext db = new CompanyDbContext();
            Brand brandToDelete = db.Brands.Where(y=>y.BrandID==BrandID).FirstOrDefault();
            db.Brands.Remove(brandToDelete);
            db.SaveChanges();
        }
    }
}
