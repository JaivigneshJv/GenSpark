using ShoppingModelLibrary;

namespace ShoppingBLLibrary.Services
{
    public interface ICustomerService
    {
        int AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        List<Customer> GetAllCustomers();
        Customer UpdateCustomer(Customer customer);
        Customer DeleteCustomer(int id);
    }
}
