using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {

        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product!;
        }

        public override Product GetByKey(int key)
        {
            Product? product = items.FirstOrDefault(p => p.Id == key);
            return product!;
        }

        public override Product Update(Product item)
        {
            Product existingProduct = GetByKey(item.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = item.Name;
                existingProduct.Price = item.Price;
                existingProduct.QuantityInHand = item.QuantityInHand;
                existingProduct.Image = item.Image;
            }
            return existingProduct!;
        }
    }
}