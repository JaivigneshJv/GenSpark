using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using ShoppingBLLibrary.Services;
using ShoppingDALLibrary;

namespace ShoppingBLLibrary.BL
{
    public class CustomerBL : ICustomerService
    {
        readonly IRepository<int, Customer> _customerRepository;

        public CustomerBL()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerBL(IRepository<int, Customer> repository)
        {
            _customerRepository = repository;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            var result = await _customerRepository.Add(customer);
            if (result != null)
            {
                return result.Id;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var result = await _customerRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var result = await _customerRepository.GetAll();
            if (result != null)
            {
                return result.ToList();
            }
            throw new NoCustomerWithGiveIdException();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var result = await _customerRepository.GetByKey(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = await _customerRepository.Update(customer);
            if (result != null)
            {
                return result;
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}
