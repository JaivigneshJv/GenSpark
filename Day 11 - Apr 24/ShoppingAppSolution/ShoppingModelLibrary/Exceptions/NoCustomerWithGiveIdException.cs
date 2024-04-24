using System;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCustomerWithGiveIdException : Exception
    {
        public NoCustomerWithGiveIdException(int customerId)
            : base($"Customer with ID {customerId} is not present.")
        {
        }
    }
}
