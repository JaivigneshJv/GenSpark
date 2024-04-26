using ShoppingModelLibrary;


namespace ShoppingBLLibrary.Services
{
    public interface IProductService
    {
        int AddProduct(Product product);
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        Product UpdateProduct(Product product);
        Product DeleteProduct(int id);
    }
}
