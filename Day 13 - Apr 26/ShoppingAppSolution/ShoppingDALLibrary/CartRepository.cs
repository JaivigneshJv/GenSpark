using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        private List<Cart> items1;

        public CartRepository()
        {
            items1 = new List<Cart>();
        }

        public CartRepository(List<Cart> items1)
        {
            this.items1 = items1;
        }

        public override Task<Cart> Add(Cart item)
        {
            items1.Add(item);
            return Task.FromResult(item);
        }

        public override async Task<Cart> Delete(int key)
        {
            Cart cart = await GetByKey(key);
            items1.Remove(cart);
            return cart;
        }

        public override Task<ICollection<Cart>> GetAll()
        {
            return Task.FromResult<ICollection<Cart>>(items1.ToList());
        }

        public override Task<Cart> GetByKey(int key)
        {
            Cart cart = items1.FirstOrDefault(c => c.Id == key);
            if (cart == null)
                throw new NoCustomerWithGiveIdException();
            return Task.FromResult(cart);
        }

        public override Task<Cart> Update(Cart item)
        {
            int index = items1.ToList().FindIndex(c => c.Id == item.Id);
            if (index == -1)
                throw new NoCustomerWithGiveIdException();
            items1[index] = item;
            return Task.FromResult(item);
        }
    }
}
