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
        public ActionResult Index(string search="", string SortColumn="ProductName", string IconClass="fa-sort-asc", int PageNo=1)
        {

            CompanyDbContext db = new CompanyDbContext();
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
                    products = products.OrderBy(temp => temp.DOP).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DOP).ToList();
            }
            else if (SortColumn == "Active")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Active).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Active).ToList();
            }

            //paging - limiting the number of records per page displayed to the user
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage))); //rounding up
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();


            return View(products);
        }

        
        public ActionResult Details(long id)
        {

            CompanyDbContext db = new CompanyDbContext();
            Product product = db.Products.Where(item => item.ProductID==id).FirstOrDefault();


            
            return View(product);


        }

        public ActionResult Create()
        {
            CompanyDbContext db = new CompanyDbContext();
            ViewBag.Categories =  db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            CompanyDbContext db = new CompanyDbContext();

            db.Products.Add(product);
            //Request.Files is an array that catches all the files submitted to the browser (built in)
       

            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0]; //assuming only one file was submitted; this also requires the encrypt type to be set in the view
                var imgBytes = new Byte[file.ContentLength]; //creating a byte array to store the file (better as more encrypted)
                file.InputStream.Read(imgBytes, 0, file.ContentLength); // writing all the bytes from the file into imgBytes
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);//convert the bytes to string before storing in DB
                product.Photo = base64String;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            CompanyDbContext db = new CompanyDbContext();

            Product productToEdit = db.Products.Where(product => product.ProductID == id).FirstOrDefault();

            
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

            return View(productToEdit);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product productToEdit = db.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();

            //update the product but dont touch the id as that is a primary key
            productToEdit.ProductName = product.ProductName;
            productToEdit.Price = product.Price;
            productToEdit.DOP = product.DOP;
            productToEdit.CategoryID = product.CategoryID;
            productToEdit.BrandID = product.BrandID;
            productToEdit.Active = product.Active;
            productToEdit.AvailabilityStatus = product.AvailabilityStatus;

            db.SaveChanges();


            return RedirectToAction("Index","Product");
        }

        public ActionResult Delete(long id)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product productTodelte = db.Products.Where(p => p.ProductID == id).FirstOrDefault();

            db.Products.Remove(productTodelte);
            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}