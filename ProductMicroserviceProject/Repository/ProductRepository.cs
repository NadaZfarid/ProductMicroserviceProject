using Microsoft.EntityFrameworkCore;
using ProductMicroserviceProject.Models;

namespace ProductMicroserviceProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddProduct(Product product)
        {
            dbContext.Products.Add(product);
            Save();
        }

        public void DeleteProduct(int id)
        {
            Product product = dbContext.Products.Find(id);
            dbContext.Products.Remove(product);
            Save();
        }

        public List<Product> GetAllProduct()
        {
            List<Product> products = dbContext.Products.ToList();
            return products;
        }

        public Product GetProductById(int productId)
        {
            Product product = dbContext.Products.Find(productId);
            return product;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public Product UpdateProduct(Product product)
        {
            dbContext.Entry(product).State = EntityState.Modified;
            Save();
            return product;
        }
    }
}
