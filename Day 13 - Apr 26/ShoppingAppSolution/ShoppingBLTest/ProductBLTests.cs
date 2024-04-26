using NUnit.Framework;
using Moq;
using ShoppingModelLibrary;
using ShoppingBLLibrary.BL;
using ShoppingDALLibrary;
using System.Collections.Generic;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLLibrary.Tests
{
    [TestFixture]
    public class ProductBLTests
    {
        private Mock<IRepository<int, Product>> _productRepositoryMock;
        private ProductBL _productBL;

        [SetUp]
        public void SetUp()
        {
            _productRepositoryMock = new Mock<IRepository<int, Product>>();
            _productBL = new ProductBL(_productRepositoryMock.Object);
        }

        [Test]
        public void AddProduct_WhenCalled_AddsProductToRepository()
        {
            Assert.Throws<NoProductWithGivenIdException>(() =>_productBL.AddProduct(null));

        }

        [Test]
        public void DeleteProduct_WhenCalled_DeletesProductFromRepository()
        {
            var product = new Product { Id = 1 };
            _productRepositoryMock.Setup(r => r.Delete(1)).Returns(product);
            var result = _productBL.DeleteProduct(1);
            Assert.That(result, Is.EqualTo(product));
            _productRepositoryMock.Verify(r => r.Delete(1), Times.Once);
        }

        [Test]
        public void GetAllProducts_WhenCalled_GetsAllProductsFromRepository()
        {
            var products = new List<Product> { new(), new() };
            _productRepositoryMock.Setup(r => r.GetAll()).Returns(products);
            var result = _productBL.GetAllProducts();
            Assert.That(result, Is.EqualTo(products));
            _productRepositoryMock.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void GetProductById_WhenCalled_GetsProductFromRepository()
        {
            var product = new Product { Id = 1 };
            _productRepositoryMock.Setup(r => r.GetByKey(1)).Returns(product);
            var result = _productBL.GetProductById(1);
            Assert.That(result, Is.EqualTo(product));
            _productRepositoryMock.Verify(r => r.GetByKey(1), Times.Once);
        }

        [Test]
        public void UpdateProduct_WhenCalled_UpdatesProductInRepository()
        {
            Assert.Throws<NoProductWithGivenIdException>(() => _productBL.AddProduct(null));

        }
    }
}
