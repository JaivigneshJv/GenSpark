using ShoppingModelLibrary;


namespace ShoppingBLLibrary.Services
{
    public interface ICartItemService
    {
        int AddCartItem(CartItem cartItem);
        CartItem GetCartItemById(int id);
        List<CartItem> GetAllCartItems();
        CartItem UpdateCartItem(CartItem cartItem);
        CartItem DeleteCartItem(int id);
    }
}
