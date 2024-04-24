using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer!;
        }

        public override Customer GetByKey(int key)
        {
            Customer? customer = items.FirstOrDefault(c => c.Id == key);
            return customer ?? throw new NoCustomerWithGiveIdException(key);
        }

        public override Customer Update(Customer item)
        {
            Customer customer = GetByKey(item.Id);
            if (customer != null)
            {
                customer = item;
            }
            return customer!; 
        }
    }
}
