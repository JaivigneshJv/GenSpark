using NUnit.Framework;
using Moq;
using ShoppingModelLibrary;
using ShoppingDALLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingDALTest
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private ProductRepository _productRepository;
        private List<Product> _items;

        [SetUp]
        public void SetUp()
        {
            _items = new List<Product>();
            _productRepository = new ProductRepository(_items);
        }

        [Test]
        public void Add_WhenCalled_AddsProductToItems()
        {
            var product = new Product();
            _productRepository.Add(product);
            Assert.That(_items, Contains.Item(product));
        }

        [Test]
        public void Delete_WhenCalled_RemovesProductFromItems()
        {
            var product = new Product { Id = 1 };
            _items.Add(product);
            _productRepository.Delete(1);
            Assert.That(_items, Does.Not.Contain(product));
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllItems()
        {
            var products = new List<Product> { new Product(), new Product() };
            _items.AddRange(products);
            var result = _productRepository.GetAll();
            Assert.That(result, Is.EquivalentTo(products));
        }

        [Test]
        public void GetByKey_WhenCalled_ReturnsProductWithGivenKey()
        {
            var product = new Product { Id = 1 };
            _items.Add(product);
            var result = _productRepository.GetByKey(1);
            Assert.That(result, Is.EqualTo(product));
        }

        [Test]
        public void Update_WhenCalled_UpdatesProductInItems()
        {
            var product = new Product { Id = 1 };
            _items.Add(product);
            var updatedProduct = new Product { Id = 1 };
            _productRepository.Update(updatedProduct);
            Assert.That(_items.First(), Is.EqualTo(updatedProduct));
        }
    }
}
