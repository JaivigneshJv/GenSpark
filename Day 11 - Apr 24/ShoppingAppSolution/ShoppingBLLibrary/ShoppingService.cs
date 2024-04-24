using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;

namespace ShoppingBLLibrary
{
    public class ShoppingService
    {
        public readonly ProductRepository _productRepository;
        public readonly CartRepository _cartRepository;

        public ShoppingService(ProductRepository productRepository, CartRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public double CalculateTotalPrice(Cart cart)
        {
            double totalPrice = 0;

            foreach (var cartItem in cart.CartItems)
            {
                Product product = _productRepository.GetByKey(cartItem.ProductId);
                totalPrice += cartItem.Price * cartItem.Quantity;
            }

            return totalPrice;
        }

        public void ApplyShippingCharge(Cart cart)
        {
            if (CalculateTotalPrice(cart) < 100)
            {
                cart.ShippingCharge = 100;
            }
        }

        public void ApplyDiscount(Cart cart)
        {
            if (cart.CartItems.Count == 3 && CalculateTotalPrice(cart) >= 1500)
            {
                double discountAmount = CalculateTotalPrice(cart) * 0.05;
                cart.Discount = discountAmount;
            }
        }

        public static void CheckMaxQuantityInCart(Cart cart)
        {
            foreach (var cartItem in cart.CartItems)
            {
                if (cartItem.Quantity > 5)
                {
                    cartItem.Quantity = 5;
                }
            }
        }
    }
}
