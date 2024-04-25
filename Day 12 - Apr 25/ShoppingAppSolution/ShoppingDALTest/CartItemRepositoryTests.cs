
using Moq;
using ShoppingModelLibrary;
using ShoppingDALLibrary;


namespace ShoppingDALTest
{
    [TestFixture]
    public class CartItemRepositoryTests
    {
        private Mock<List<CartItem>> _itemsMock;
        private CartItemRepository _cartItemRepository;

        [SetUp]
        public void SetUp()
        {
            _itemsMock = new Mock<List<CartItem>>();
            _cartItemRepository = new CartItemRepository(_itemsMock.Object);
        }

        [Test]
        public void Delete_WhenCalled_RemovesCartItemFromItems()
        {
            var cartItem = new CartItem { CartId = 1 };
            _itemsMock.Setup(i => i.Remove(cartItem)).Returns(true);
            var result = _cartItemRepository.Delete(1);
            Assert.That(result, Is.EqualTo(cartItem));
            _itemsMock.Verify(i => i.Remove(cartItem), Times.Once);
        }

        [Test]
        public void GetByKey_WhenCalled_ReturnsCartItemFromItems()
        {
            var cartItem = new CartItem { CartId = 1 };
            _itemsMock.Setup(i => i.Find(p => p.CartId == 1)).Returns(cartItem);
            var result = _cartItemRepository.GetByKey(1);
            Assert.That(result, Is.EqualTo(cartItem));
        }

        [Test]
        public void Update_WhenCalled_UpdatesCartItemInItems()
        {
            var cartItem = new CartItem { CartId = 1 };
            _itemsMock.Setup(i => i.Find(p => p.CartId == 1)).Returns(cartItem);
            var result = _cartItemRepository.Update(cartItem);
            Assert.That(result, Is.EqualTo(cartItem));
        }
    }
}
