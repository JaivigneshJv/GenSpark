using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingBLLibrary.Services;
using ShoppingDALLibrary;


namespace ShoppingBLLibrary.BL
{
    public class CartBL : ICartService
    {
        private const double SHIPPING_CHARGE = 100.00;
        private const double DISCOUNT_PERCENTAGE = 0.05;

        private readonly IRepository<int, Cart> _cartRepository;

        public CartBL()
        {
            _cartRepository = new CartRepository();
        }

        public CartBL(IRepository<int, Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<int> AddCart(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart), "Cart cannot be null.");
            }

            ProccessCart(cart);

            Cart addedCart = await _cartRepository.Add(cart);
            return addedCart.Id;
        }

        public async Task<Cart> DeleteCart(int id)
        {
            Cart deletedCart = await _cartRepository.Delete(id);
            return deletedCart ?? throw new CartNotFoundException();
        }

        public async Task<List<Cart>> GetAllCarts()
        {
            ICollection<Cart> carts = await _cartRepository.GetAll();
            if (carts.Count == 0)
            {
                throw new CartNotFoundException();
            }
            return carts.ToList();
        }

        public async Task<Cart> GetCartById(int id)
        {
            Cart cart = await _cartRepository.GetByKey(id);
            return cart ?? throw new CartNotFoundException();
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart), "Cart cannot be null.");
            }

            ProccessCart(cart);

            Cart updatedCart = await _cartRepository.Update(cart);
            return updatedCart ?? throw new CartNotFoundException();
        }

        private static void ProccessCart(Cart cart)
        {
            double totalPrice = 0;
            foreach (var item in cart.CartItems)
            {
                totalPrice += item.Price * item.Quantity;
            }

            if (totalPrice < 100)
            {
                totalPrice += SHIPPING_CHARGE;
            }

            if (cart.CartItems.Count == 3 && totalPrice >= 1500)
            {
                totalPrice -= totalPrice * DISCOUNT_PERCENTAGE;
            }

            foreach (var item in cart.CartItems)
            {
                if (item.Quantity > 5)
                {
                    throw new ArgumentException($"Maximum quantity of products in cart cannot be more than 5.");
                }
            }

            cart.TotalPrice = totalPrice;
        }
    }
}
