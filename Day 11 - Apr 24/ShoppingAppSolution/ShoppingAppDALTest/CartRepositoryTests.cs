
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;


namespace ShoppingAppDALTest
{
    public class CartRepositoryTests
    {
        private CartRepository? _cartRepository;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
        }

        [Test]
        public void GetByKey_ShouldReturnCart_WhenCartExists()
        {
            var cart = new Cart { Id = 1 };
            _cartRepository!.Add(cart);

            var result = _cartRepository.GetByKey(1);

            Assert.That(result, Is.EqualTo(cart));
        }

        [Test]
        public void GetByKey_ShouldThrowException_WhenCartDoesNotExist()
        {
            Assert.Throws<NoCartWithGivenIdException>(() => _cartRepository!.GetByKey(1));
        }

        [Test]
        public void Delete_ShouldRemoveCart_WhenCartExists()
        {
            var cart = new Cart { Id = 1 };
            _cartRepository!.Add(cart);

            _cartRepository.Delete(1);

            Assert.That(_cartRepository.GetAll().Any(c => c.Id == 1), Is.False);
        }
    }
}
