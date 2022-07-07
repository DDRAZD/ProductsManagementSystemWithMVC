using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.ServiceContracts;
using Company.DataLayer;
//using Company.DataLayer; as we have the repository layer, we do not reference the data layer directly from the service layer anymore
using Company.DomainModels;
using Company.RepositoryContracts;
using Company.RepositoryLayer;

//business logic in the service is to check conditions and do some calculations; it is not to interact with the data base. That is done in the repositoty layer


namespace Company.ServiceLayer
{
    public class ProductService : IProductService
    {
        // CompanyDbContext db;
        IProductsRepository prodRep;


        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public ProductService(IProductsRepository r)//dependancy injection
        {
           this.prodRep=r;
        }

        public void DeleteProduct(long ProductID)
        {
           prodRep.DeleteProduct(ProductID);
        }

        public Product GetProductByProductID(long ProductID)
        {
            Product p = prodRep.GetProductByProductID(ProductID);
            return p;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = prodRep.GetProducts();
            return products;
        }

        public void InsertProduct(Product p)
        {
            if(p.Price<=100000)
            {
                prodRep.InsertProduct(p);
            }   
            else
            {
                throw new Exception("Price exceeds the limit");
            }
                   
        }

        public List<Product> SearchProducts(string ProductName)
        {
           List<Product> products =prodRep.SearchProducts(ProductName);
            return products;
        }

        public void UpdateProduct(Product p)
        {
           prodRep.UpdateProduct(p);
            
          
        }
    }
}
