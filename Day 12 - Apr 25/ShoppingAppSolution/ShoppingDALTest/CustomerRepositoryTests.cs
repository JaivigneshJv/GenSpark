using NUnit.Framework;
using Moq;
using ShoppingModelLibrary;
using ShoppingDALLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingDALTest
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _customerRepository;
        private List<Customer> _items;

        [SetUp]
        public void SetUp()
        {
            _items = new List<Customer>();
            _customerRepository = new CustomerRepository(_items);
        }

        [Test]
        public void Add_WhenCalled_AddsCustomerToItems()
        {
            var customer = new Customer();
            _customerRepository.Add(customer);
            Assert.That(_items, Contains.Item(customer));
        }

        [Test]
        public void Delete_WhenCalled_RemovesCustomerFromItems()
        {
            var customer = new Customer { Id = 1 };
            _items.Add(customer);
            _customerRepository.Delete(1);
            Assert.That(_items, Does.Not.Contain(customer));
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllItems()
        {
            var customers = new List<Customer> { new Customer(), new Customer() };
            _items.AddRange(customers);
            var result = _customerRepository.GetAll();
            Assert.That(result, Is.EquivalentTo(customers));
        }

        [Test]
        public void GetByKey_WhenCalled_ReturnsCustomerWithGivenKey()
        {
            var customer = new Customer { Id = 1 };
            _items.Add(customer);
            var result = _customerRepository.GetByKey(1);
            Assert.That(result, Is.EqualTo(customer));
        }

        [Test]
        public void Update_WhenCalled_UpdatesCustomerInItems()
        {
            var customer = new Customer { Id = 1 };
            _items.Add(customer);
            var updatedCustomer = new Customer { Id = 1 };
            _customerRepository.Update(updatedCustomer);
            Assert.That(_items.First(), Is.EqualTo(updatedCustomer));
        }
    }
}
