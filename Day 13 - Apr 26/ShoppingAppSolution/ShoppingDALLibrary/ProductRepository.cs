using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        private List<Product> items1;

        public ProductRepository()
        {
        }

        public ProductRepository(List<Product> items1)
        {
            this.items1 = items1;
        }

        public override Product Add(Product item)
        {
            items.Add(item);
            return item;
        }

        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            items.Remove(product);
            return product;
        }

        public override ICollection<Product> GetAll()
        {
            return items.ToList();
        }

        public override Product GetByKey(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product == null)
                throw new NoCustomerWithGiveIdException();
            return product;
        }

        public override Product Update(Product item)
        {
            int index = items.ToList().FindIndex(p => p.Id == item.Id);
            if (index == -1)
                throw new NoCustomerWithGiveIdException();
            items[index] = item;
            return item;
        }
    }
}
