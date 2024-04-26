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
        public int AddCustomer(Customer customer)
        {
            var result = _customerRepository.Add(customer);
            if (result != null)
            {
                return result.Id;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public Customer DeleteCustomer(int id)
        {
            var result = _customerRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public List<Customer> GetAllCustomers()
        {
            var result = _customerRepository.GetAll();
            if (result != null)
            {
                return result.ToList();
            }
            throw new NoCustomerWithGiveIdException();
        }

        public Customer GetCustomerById(int id)
        {
            var result = _customerRepository.GetByKey(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var result = _customerRepository.Update(customer);
            if (result != null)
            {
                return result;
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}
