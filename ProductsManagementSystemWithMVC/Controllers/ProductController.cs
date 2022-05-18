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
            List<Product> products = new List<Product>()
            {
                new Product(){ ProductId = 1, ProductName = "AC", Rate=45000},
                new Product(){ ProductId = 2, ProductName ="Mobile", Rate=38000},
                new Product{ ProductId = 3, ProductName ="Bike", Rate=94000}
            };
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
            List<Product> products = new List<Product>()
            {
                new Product(){ ProductId = 1, ProductName = "AC", Rate=45000},
                new Product(){ ProductId = 2, ProductName ="Mobile", Rate=38000},
                new Product{ ProductId = 3, ProductName ="Bike", Rate=94000}
            };
            Product matchingProduct=null;

            foreach(Product product in products)
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
        public ActionResult Create(Product product)
        {
            return View();
        }
    }
}