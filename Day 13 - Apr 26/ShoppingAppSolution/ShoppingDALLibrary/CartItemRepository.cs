

using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        private List<CartItem> @object;

        public CartItemRepository()
        {
            @object = new List<CartItem>();
        }

        public CartItemRepository(List<CartItem> @object)
        {
            this.@object = @object;
        }

        public override async Task<CartItem> Delete(int key)
        {
            CartItem cartItem = await GetByKey(key);
            if (cartItem != null)
            {
                @object.Remove(cartItem); // Use the correct list name
                return cartItem;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public override async Task<CartItem> GetByKey(int key)
        {
            CartItem cartItem = @object.Find(p => p.CartId == key); // Use the correct list name
            if (cartItem != null)
            {
                return cartItem;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public override async Task<CartItem> Update(CartItem item)
        {
            CartItem cartItem = await GetByKey(item.CartId);
            if (cartItem != null)
            {
                cartItem = item;
                return cartItem;
            }
            throw new NoCartItemWithGivenIdException();
        }
    }

}