using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using ShoppingBLLibrary.Services;
using ShoppingDALLibrary;


namespace ShoppingBLLibrary.BL
{
    public class CartItemBL : ICartItemService
    {
        readonly IRepository<int, CartItem> _cartItemRepository;

        public CartItemBL()
        {
            _cartItemRepository = new CartItemRepository();
        }

        public CartItemBL(IRepository<int, CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<int> AddCartItem(CartItem cartItem)
        {
            if (cartItem == null)
            {
                throw new NullReferenceException();
            }
            ProcessCartItem(cartItem);
            CartItem result = await _cartItemRepository.Add(cartItem);
            if (result != null)
            {
                return result.ProductId;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public async Task<CartItem> DeleteCartItem(int id)
        {
            var result = await _cartItemRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public async Task<List<CartItem>> GetAllCartItems()
        {
            var result = await _cartItemRepository.GetAll();
            if (result.Count != 0)
            {
                return result.ToList();
            }
            throw new NoCartItemWithGivenIdException();
        }

        public async Task<CartItem> GetCartItemById(int id)
        {
            var result = await _cartItemRepository.GetByKey(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public async Task<CartItem> UpdateCartItem(CartItem cartItem)
        {
            if (cartItem == null)
            {
                throw new NullReferenceException();
            }
            ProcessCartItem(cartItem);
            var result = await _cartItemRepository.Update(cartItem);
            if (result != null)
            {
                return result;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public static void ProcessCartItem(CartItem cartItem)
        {
            if (cartItem.Quantity > 5)
            {
                throw new ArgumentException("Maximum quantity of product in cart should be less than 5");
            }
        }
    }

}
