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
        public ActionResult Index(string search="", string SortColumn="ProductName", string IconClass="fa-sort-asc")
        {

            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Product> products = db.Products.Where(item => item.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            //sorting is done at the controller level, before sent to the view

            if(SortColumn == "ProductID")
            {
               if(IconClass == "fa-sort-asc")
                   products = products.OrderBy(temp => temp.ProductID).ToList();
               else
                    products=products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (SortColumn =="ProductName")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (SortColumn=="Price")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();

            }
            else if (SortColumn=="AvailabilityStatus")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (SortColumn == "BrandID")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.BrandID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.BrandID).ToList();
            }
            else if (SortColumn == "CategoryID")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.CategoryID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.CategoryID).ToList();
            }
            else if (SortColumn == "DateOfPurchase")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DateOfPurchase).ToList();
            }
            else if (SortColumn == "Active")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Active).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Active).ToList();
            }

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
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.Categories =  db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

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

            
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

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