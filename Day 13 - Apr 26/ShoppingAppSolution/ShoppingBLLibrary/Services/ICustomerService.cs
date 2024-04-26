using ShoppingModelLibrary;

namespace ShoppingBLLibrary.Services
{
    public interface ICustomerService
    {
        Task<int> AddCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
    }
}
