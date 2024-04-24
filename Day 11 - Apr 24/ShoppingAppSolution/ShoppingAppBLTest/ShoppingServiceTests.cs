using NUnit.Framework;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System.Collections.Generic;

namespace ShoppingAppBLTest
{
    public class ShoppingServiceTests
    {
        private ShoppingService _shoppingService;
        private ProductRepository _productRepository;
        private CartRepository _cartRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
            _cartRepository = new CartRepository();
            _shoppingService = new ShoppingService(_productRepository, _cartRepository);
        }

        [Test]
        public void CalculateTotalPrice_ShouldReturnCorrectTotal()
        {
            var cart = new Cart
            {
                CartItems = new List<CartItem>
                    {
                        new() { ProductId = 1, Price = 100, Quantity = 2 },
                        new() { ProductId = 2, Price = 200, Quantity = 1 }
                    }
            };

            double totalPrice = _shoppingService.CalculateTotalPrice(cart);

            Assert.That(totalPrice, Is.EqualTo(400));
        }

        [Test]
        public void ApplyShippingCharge_ShouldApplyChargeIfTotalLessThan100()
        {
            var cart = new Cart
            {
                CartItems = new List<CartItem>
                    {
                        new() { ProductId = 1, Price = 50, Quantity = 1 }
                    }
            };

            _shoppingService.ApplyShippingCharge(cart);

            Assert.That(cart.ShippingCharge, Is.EqualTo(100));
        }

        [Test]
        public void ApplyDiscount_ShouldApplyDiscountIfThreeItemsAndTotalOver1500()
        {
            var cart = new Cart
            {
                CartItems = new List<CartItem>
                    {
                        new() { ProductId = 1, Price = 500, Quantity = 1 },
                        new() { ProductId = 2, Price = 500, Quantity = 1 },
                        new() { ProductId = 3, Price = 500, Quantity = 1 }
                    }
            };

            _shoppingService.ApplyDiscount(cart);

            Assert.That(cart.Discount, Is.EqualTo(75));
        }

        [Test]
        public void CheckMaxQuantityInCart_ShouldLimitQuantityToFive()
        {
            var cart = new Cart
            {
                CartItems = new List<CartItem>
                    {
                        new() { ProductId = 1, Price = 100, Quantity = 10 }
                    }
            };

            ShoppingService.CheckMaxQuantityInCart(cart);

            Assert.That(cart.CartItems[0].Quantity, Is.EqualTo(5));
        }

        [Test]
        public void CalculateTotalPrice_ShouldReturnZeroForEmptyCart()
        {
            var cart = new Cart
            {
                CartItems = new List<CartItem>()
            };

            double totalPrice = _shoppingService.CalculateTotalPrice(cart);

            Assert.That(totalPrice, Is.EqualTo(0));
        }

        [Test]
        public void ApplyShippingCharge_ShouldNotApplyChargeIfTotalEqualTo100()
        {
            var cart = new Cart
            {
                CartItems = new List<CartItem>
                    {
                        new() { ProductId = 1, Price = 100, Quantity = 1 }
                    }
            };

            _shoppingService.ApplyShippingCharge(cart);

            Assert.That(cart.ShippingCharge, Is.EqualTo(0));
        }

        [Test]
        public void ApplyDiscount_ShouldNotApplyDiscountIfTwoItemsAndTotalOver1500()
        {
            var cart = new Cart
            {
                CartItems = new List<CartItem>
                    {
                        new() { ProductId = 1, Price = 750, Quantity = 1 },
                        new() { ProductId = 2, Price = 750, Quantity = 1 }
                    }
            };

            _shoppingService.ApplyDiscount(cart);

            Assert.That(cart.Discount, Is.EqualTo(0));
        }

        [Test]
        public void CheckMaxQuantityInCart_ShouldThrowExceptionIfCartIsNull()
        {
            Cart? cart = null;
            Assert.Throws<NullReferenceException>(() => ShoppingService.CheckMaxQuantityInCart(cart!));
        }
    }
}
