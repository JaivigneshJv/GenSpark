using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        private List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>();
        }

        public override async Task<Customer> Add(Customer item)
        {
            customers.Add(item);
            return item;
        }

        public override async Task<Customer> Delete(int key)
        {
            Customer customer = await GetByKey(key);
            if (customer != null)
            {
                customers.Remove(customer);
                return customer;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public override async Task<ICollection<Customer>> GetAll()
        {
            return customers;
        }

        public override async Task<Customer> GetByKey(int key)
        {
            Customer customer = customers.Find(c => c.Id == key);
            if (customer != null)
            {
                return customer;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override async Task<Customer> Update(Customer item)
        {
            Customer customer = await GetByKey(item.Id);
            if (customer != null)
            {
                customer = item;
                return customer;
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}
