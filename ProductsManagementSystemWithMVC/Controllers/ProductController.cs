using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsManagementSystemWithMVC.Models;


namespace ProductsManagementSystemWithMVC.Controllers
{
    public class ProductController : Controller
    {
        [Route("Product/Index")]
        public ActionResult Index(string search="")
        {

            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Product> products = db.Products.Where(item => item.ProductName.Contains(search)).ToList();

            ViewBag.Search = search;

           
            return View(products);
        }

        
        public ActionResult Details(long id)
        {

            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product product = db.Products.Where(item => item.ProductID==id).FirstOrDefault();


            
            return View(product);


        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();

            Product productToEdit = db.Products.Where(product => product.ProductID == id).FirstOrDefault();

            return View(productToEdit);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product productToEdit = db.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();

            //update the product but dont touch the id as that is a primary key
            productToEdit.ProductName = product.ProductName;
            productToEdit.Price = product.Price;
            productToEdit.DateOfPurchase = product.DateOfPurchase;
            productToEdit.CategoryID = product.CategoryID;
            productToEdit.BrandID = product.BrandID;
            productToEdit.Active = product.Active;
            productToEdit.AvailabilityStatus = product.AvailabilityStatus;

            db.SaveChanges();


            return RedirectToAction("Index","Product");
        }

        public ActionResult Delete(long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product productTodelte = db.Products.Where(p => p.ProductID == id).FirstOrDefault();

            db.Products.Remove(productTodelte);
            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}