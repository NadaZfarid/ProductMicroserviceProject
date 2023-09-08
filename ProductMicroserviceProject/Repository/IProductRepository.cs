using ProductMicroserviceProject.Models;

namespace ProductMicroserviceProject.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProduct();
        Product GetProductById(int productId);
        void AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(int id);
        void Save();

    }
}
