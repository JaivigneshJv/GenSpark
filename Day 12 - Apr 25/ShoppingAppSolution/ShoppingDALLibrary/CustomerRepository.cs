using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override Customer Add(Customer item)
        {
            items.Add(item);
            return item;
        }

        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            items.Remove(customer);
            return customer;
        }

        public override ICollection<Customer> GetAll()
        {
            return items.ToList();
        }

        public override Customer GetByKey(int key)
        {
            Customer customer = items.FirstOrDefault(c => c.Id == key);
            if (customer == null)
                throw new NoCustomerWithGiveIdException();
            return customer;
        }

        public override Customer Update(Customer item)
        {
            int index = items.ToList().FindIndex(c => c.Id == item.Id);
            if (index == -1)
                throw new NoCustomerWithGiveIdException();
            items[index] = item;
            return item;
        }
    }
}
