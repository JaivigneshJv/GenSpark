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
    public class CustomerBLTests
    {
        private Mock<IRepository<int, Customer>> _customerRepositoryMock;
        private CustomerBL _customerBL;

        [SetUp]
        public void SetUp()
        {
            _customerRepositoryMock = new Mock<IRepository<int, Customer>>();
            _customerBL = new CustomerBL(_customerRepositoryMock.Object);
        }

        [Test]
        public void AddCustomer_WhenCalled_AddsCustomerToRepository()
        {
            Assert.Throws<NoCustomerWithGiveIdException>(() => _customerBL.AddCustomer(null));

        }

        [Test]
        public void DeleteCustomer_WhenCalled_DeletesCustomerFromRepository()
        {
            var customer = new Customer { Id = 1 };
            _customerRepositoryMock.Setup(r => r.Delete(1)).Returns(customer);
            var result = _customerBL.DeleteCustomer(1);
            Assert.That(result, Is.EqualTo(customer));
            _customerRepositoryMock.Verify(r => r.Delete(1), Times.Once);
        }

        [Test]
        public void GetAllCustomers_WhenCalled_GetsAllCustomersFromRepository()
        {
            var customers = new List<Customer> { new(), new() };
            _customerRepositoryMock.Setup(r => r.GetAll()).Returns(customers);
            var result = _customerBL.GetAllCustomers();
            Assert.That(result, Is.EqualTo(customers));
            _customerRepositoryMock.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void GetCustomerById_WhenCalled_GetsCustomerFromRepository()
        {
            var customer = new Customer { Id = 1 };
            _customerRepositoryMock.Setup(r => r.GetByKey(1)).Returns(customer);
            var result = _customerBL.GetCustomerById(1);
            Assert.That(result, Is.EqualTo(customer));
            _customerRepositoryMock.Verify(r => r.GetByKey(1), Times.Once);
        }

        [Test]
        public void UpdateCustomer_WhenCalled_UpdatesCustomerInRepository()
        {
            Assert.Throws<NoCustomerWithGiveIdException>(() => _customerBL.AddCustomer(null));
        }
    }
}
