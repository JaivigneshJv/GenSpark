using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart!;
        }

        public override Cart GetByKey(int key)
        {
            Cart ? cart = items.FirstOrDefault(c => c.Id == key);
            return cart ?? throw new NoCartWithGivenIdException(key);
        }

        public override Cart Update(Cart item)
        {
            Cart cart = GetByKey(item.Id);
            if (cart != null)
            {
                cart = item;
            }
            return cart!;
        }
    }
}
