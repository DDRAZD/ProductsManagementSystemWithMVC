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
        
        public ActionResult Index()
        {

            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Product> products = db.Products.ToList();


            /* List<ProductExample> products = new List<ProductExample>()
            {
                new ProductExample(){ ProductId = 1, ProductName = "AC", Rate=45000},
                new ProductExample(){ ProductId = 2, ProductName ="Mobile", Rate=38000},
                new ProductExample(){ ProductId = 3, ProductName ="Bike", Rate=94000}
            };*/
            ///  ViewBag.Products = products;
            return View(products);
        }

        /// <summary>
        /// will pull product details based on ID; the ID is configured in the RouteConfig.cs as optional 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
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
            //ViewBag.MatchingProduct = matchingProduct;
            return View(matchingProduct);


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