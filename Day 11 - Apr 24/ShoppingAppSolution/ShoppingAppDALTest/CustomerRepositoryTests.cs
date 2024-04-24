using NUnit.Framework;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Linq;

namespace ShoppingAppDALTest
{
    public class CustomerRepositoryTests
    {
        private CustomerRepository _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
        }

        [Test]
        public void GetByKey_ShouldReturnCustomer_WhenCustomerExists()
        {
            var customer = new Customer { Id = 1 };
            _customerRepository.Add(customer);

            var result = _customerRepository.GetByKey(1);

            Assert.That(result, Is.EqualTo(customer));
        }

        [Test]
        public void GetByKey_ShouldThrowException_WhenCustomerDoesNotExist()
        {
            Assert.Throws<NoCustomerWithGiveIdException>(() => _customerRepository.GetByKey(1));
        }

        [Test]
        public void Delete_ShouldRemoveCustomer_WhenCustomerExists()
        {
            var customer = new Customer { Id = 1 };
            _customerRepository.Add(customer);

            _customerRepository.Delete(1);

            Assert.That(_customerRepository.GetAll().Any(c => c.Id == 1), Is.False);
        }
    }
}
