using ShoppingModelLibrary;


namespace ShoppingBLLibrary.Services
{
    public interface IProductService
    {
        Task<int> AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int id);
    }
}
