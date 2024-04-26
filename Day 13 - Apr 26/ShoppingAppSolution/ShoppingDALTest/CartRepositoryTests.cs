using NUnit.Framework;
using Moq;
using ShoppingModelLibrary;
using ShoppingDALLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingDALTest
{
    [TestFixture]
    public class CartRepositoryTests
    {
        private CartRepository _cartRepository;
        private List<Cart> _items;

        [SetUp]
        public void SetUp()
        {
            _items = new List<Cart>();
            _cartRepository = new CartRepository(_items);
        }

        [Test]
        public void Add_WhenCalled_AddsCartToItems()
        {
            var cart = new Cart();
            _cartRepository.Add(cart);
            Assert.That(_items, Contains.Item(cart));
        }

        [Test]
        public void Delete_WhenCalled_RemovesCartFromItems()
        {
            var cart = new Cart { Id = 1 };
            _items.Add(cart);
            _cartRepository.Delete(1);
            Assert.That(_items, Does.Not.Contain(cart));
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllItems()
        {
            var carts = new List<Cart> { new Cart(), new Cart() };
            _items.AddRange(carts);
            var result = _cartRepository.GetAll();
            Assert.That(result, Is.EquivalentTo(carts));
        }

        [Test]
        public void GetByKey_WhenCalled_ReturnsCartWithGivenKey()
        {
            var cart = new Cart { Id = 1 };
            _items.Add(cart);
            var result = _cartRepository.GetByKey(1);
            Assert.That(result, Is.EqualTo(cart));
        }

        [Test]
        public void Update_WhenCalled_UpdatesCartInItems()
        {
            var cart = new Cart { Id = 1 };
            _items.Add(cart);
            var updatedCart = new Cart { Id = 1 };
            _cartRepository.Update(updatedCart);
            Assert.That(_items.First(), Is.EqualTo(updatedCart));
        }
    }
}
