using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Company.DomainModels;
using Company.DataLayer;

namespace ProductsManagementSystemWithMVC.ApiControllers
{
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
    }
}
