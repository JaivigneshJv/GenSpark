using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        private List<Product> items1;

        public ProductRepository()
        {
            items1 = new List<Product>();
        }

        public ProductRepository(List<Product> items1)
        {
            this.items1 = items1;
        }

        public override Task<Product> Add(Product item)
        {
            items1.Add(item);
            return Task.FromResult(item);
        }

        public override async Task<Product> Delete(int key)
        {
            Product product = await GetByKey(key);
            items1.Remove(product);
            return product;
        }

        public override Task<ICollection<Product>> GetAll()
        {
            return Task.FromResult<ICollection<Product>>(items1.ToList());
        }

        public override Task<Product> GetByKey(int key)
        {
            Product product = items1.FirstOrDefault(p => p.Id == key);
            if (product == null)
                throw new NoCustomerWithGiveIdException();
            return Task.FromResult(product);
        }

        public override Task<Product> Update(Product item)
        {
            int index = items1.ToList().FindIndex(p => p.Id == item.Id);
            if (index == -1)
                throw new NoCustomerWithGiveIdException();
            items1[index] = item;
            return Task.FromResult(item);
        }
    }
}
