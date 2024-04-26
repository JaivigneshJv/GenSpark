using NUnit.Framework;
using Moq;
using ShoppingModelLibrary;
using ShoppingBLLibrary.BL;
using ShoppingDALLibrary;
using System.Collections.Generic;

namespace ShoppingBLLibrary.Tests
{
    [TestFixture]
    public class CartItemBLTests
    {
        private Mock<IRepository<int, CartItem>> _cartItemRepositoryMock;
        private CartItemBL _cartItemBL;

        [SetUp]
        public void SetUp()
        {
            _cartItemRepositoryMock = new Mock<IRepository<int, CartItem>>();
            _cartItemBL = new CartItemBL(_cartItemRepositoryMock.Object);
        }

        [Test]
        public void AddCartItem_WhenCalled_AddsCartItemToRepository()
        {
            Assert.Throws<NullReferenceException>(() => _cartItemBL.AddCartItem(null));
        }

        [Test]
        public void DeleteCartItem_WhenCalled_DeletesCartItemFromRepository()
        {
            var cartItem = new CartItem { ProductId = 1 };
            _cartItemRepositoryMock.Setup(r => r.Delete(1)).Returns(cartItem);
            var result = _cartItemBL.DeleteCartItem(1);
            Assert.That(result, Is.EqualTo(cartItem));
            _cartItemRepositoryMock.Verify(r => r.Delete(1), Times.Once);
        }

        [Test]
        public void GetAllCartItems_WhenCalled_GetsAllCartItemsFromRepository()
        {
            var cartItems = new List<CartItem> { new() , new() };
            _cartItemRepositoryMock.Setup(r => r.GetAll()).Returns(cartItems);
            var result = _cartItemBL.GetAllCartItems();
            Assert.That(result, Is.EqualTo(cartItems));
            _cartItemRepositoryMock.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void GetCartItemById_WhenCalled_GetsCartItemFromRepository()
        {
            var cartItem = new CartItem { ProductId = 1 };
            _cartItemRepositoryMock.Setup(r => r.GetByKey(1)).Returns(cartItem);
            var result = _cartItemBL.GetCartItemById(1);
            Assert.That(result, Is.EqualTo(cartItem));
            _cartItemRepositoryMock.Verify(r => r.GetByKey(1), Times.Once);
        }

        [Test]
        public void UpdateCartItem_WhenCalled_UpdatesCartItemInRepository()
        {
            Assert.Throws<NullReferenceException>(() => _cartItemBL.AddCartItem(null));

        }

        [Test]
        public void ProcessCartItem_WhenQuantityIsMoreThan5_ThrowsArgumentException()
        {
            var cartItem = new CartItem { Quantity = 6 };
            Assert.Throws<ArgumentException>(() => CartItemBL.ProcessCartItem(cartItem));
        }
    }
}
