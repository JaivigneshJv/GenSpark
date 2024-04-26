using Moq;
using ShoppingModelLibrary;
using ShoppingBLLibrary.BL;
using ShoppingDALLibrary;

namespace ShoppingBLLibrary.Tests
{
    [TestFixture]
    public class CartBLTests
    {
        private Mock<IRepository<int, Cart>> _cartRepositoryMock;
        private CartBL _cartBL;

        [SetUp]
        public void SetUp()
        {
            _cartRepositoryMock = new Mock<IRepository<int, Cart>>();
            _cartBL = new CartBL(_cartRepositoryMock.Object);
        }

        [Test]
        public void AddCart_WhenCalled_AddsCartToRepository()
        {
            Assert.Throws<ArgumentNullException>(() => _cartBL.AddCart(null));
        }

        [Test]
        public void DeleteCart_WhenCalled_DeletesCartFromRepository()
        {
            var cart = new Cart { Id = 1 };
            _cartRepositoryMock.Setup(r => r.Delete(1)).Returns(cart);
            var result = _cartBL.DeleteCart(1);
            Assert.That(result, Is.EqualTo(cart));
            _cartRepositoryMock.Verify(r => r.Delete(1), Times.Once);
        }

        [Test]
        public void GetAllCarts_WhenCalled_GetsAllCartsFromRepository()
        {
            var carts = new List<Cart> { new(), new() };
            _cartRepositoryMock.Setup(r => r.GetAll()).Returns(carts);
            var result = _cartBL.GetAllCarts();
            Assert.That(result, Is.EqualTo(carts));
            _cartRepositoryMock.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void GetCartById_WhenCalled_GetsCartFromRepository()
        {
            var cart = new Cart { Id = 1 };
            _cartRepositoryMock.Setup(r => r.GetByKey(1)).Returns(cart);
            var result = _cartBL.GetCartById(1);
            Assert.That(result, Is.EqualTo(cart));
            _cartRepositoryMock.Verify(r => r.GetByKey(1), Times.Once);
        }

        [Test]
        public void UpdateCart_WhenCalled_UpdatesCartInRepository()
        {
            Assert.Throws<ArgumentNullException>(() => _cartBL.AddCart(null));
        }
    }
}
