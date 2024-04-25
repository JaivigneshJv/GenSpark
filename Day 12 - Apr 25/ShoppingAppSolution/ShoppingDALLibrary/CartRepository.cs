using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        private List<Cart> items1;

        public CartRepository()
        {
        }

        public CartRepository(List<Cart> items1)
        {
            this.items1 = items1;
        }

        public override Cart Add(Cart item)
        {
            items.Add(item);
            return item;
        }

        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            items.Remove(cart);
            return cart;
        }

        public override ICollection<Cart> GetAll()
        {
            return items.ToList();
        }

        public override Cart GetByKey(int key)
        {
            Cart cart = items.FirstOrDefault(c => c.Id == key);
            if (cart == null)
                throw new NoCustomerWithGiveIdException();
            return cart;
        }

        public override Cart Update(Cart item)
        {
            int index = items.ToList().FindIndex(c => c.Id == item.Id);
            if (index == -1)
                throw new NoCustomerWithGiveIdException();
            items[index] = item;
            return item;
        }
    }
}
