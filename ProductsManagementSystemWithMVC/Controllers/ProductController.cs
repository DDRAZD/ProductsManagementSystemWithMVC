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


            /*
            List<ProductExample> products = new List<ProductExample>()
            {
                new ProductExample(){ ProductId = 1, ProductName = "AC", Rate=45000},
                new ProductExample(){ ProductId = 2, ProductName ="Mobile", Rate=38000},
                new ProductExample{ ProductId = 3, ProductName ="Bike", Rate=94000}
            };
            ProductExample matchingProduct =null;

            foreach(ProductExample product in products)
            {
                if(product.ProductId == id)
                {
                    matchingProduct = product;

                }               
            }

            if(matchingProduct == null)
            {
                return Content("product cannot be found");
            }
            //ViewBag.MatchingProduct = matchingProduct;*/
            return View(product);


        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductExample product)
        {
            return View();
        }
    }
}