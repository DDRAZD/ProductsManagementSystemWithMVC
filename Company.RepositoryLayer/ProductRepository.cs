using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
using Company.RepositoryContracts;
using Company.DataLayer;

namespace Company.RepositoryLayer
{
    public class ProductRepository : IProductsRepository
    {
        CompanyDbContext db;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public ProductRepository()
        {
            db = new CompanyDbContext();
        }

        public void DeleteProduct(long ProductID)
        {
            Product existingProducts = db.Products.Where(item => item.ProductID == ProductID).FirstOrDefault();
            db.Products.Remove(existingProducts);
            db.SaveChanges();
        }

        public Product GetProductByProductID(long ProductID)
        {
            Product p = db.Products.Where(item => item.ProductID == ProductID).FirstOrDefault();
            return p;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }

        public void InsertProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }

        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = db.Products.Where(p => p.ProductName.Contains(ProductName)).ToList();
            return products;
        }

        public void UpdateProduct(Product p)
        {
            Product productToEdit = db.Products.Where(item => item.ProductID == p.ProductID).FirstOrDefault();
            //update the product but dont touch the id as that is a primary key
            productToEdit.ProductName = p.ProductName;
            productToEdit.Price = p.Price;
            productToEdit.DOP = p.DOP;
            productToEdit.CategoryID = p.CategoryID;
            productToEdit.BrandID = p.BrandID;
            productToEdit.Active = p.Active;
            productToEdit.AvailabilityStatus = p.AvailabilityStatus;
            productToEdit.Photo = p.Photo;

            db.SaveChanges();
        }
    }
}
