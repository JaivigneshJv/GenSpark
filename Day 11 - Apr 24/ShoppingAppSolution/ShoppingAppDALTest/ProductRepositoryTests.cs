using NUnit.Framework;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Linq;

namespace ShoppingAppDALTest
{
    public class ProductRepositoryTests
    {
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
        }

        [Test]
        public void GetByKey_ShouldReturnProduct_WhenProductExists()
        {
            var product = new Product { Id = 1 };
            _productRepository.Add(product);

            var result = _productRepository.GetByKey(1);

            Assert.That(result, Is.EqualTo(product));
        }

        [Test]
        public void Delete_ShouldRemoveProduct_WhenProductExists()
        {
            var product = new Product { Id = 1 };
            _productRepository.Add(product);

            _productRepository.Delete(1);

            Assert.That(_productRepository.GetAll().Any(p => p.Id == 1), Is.False);
        }
    }
}
