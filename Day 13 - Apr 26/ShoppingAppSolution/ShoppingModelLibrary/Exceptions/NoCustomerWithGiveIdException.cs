namespace ShoppingModelLibrary.Exceptions
{
    public class NoCustomerWithGiveIdException : Exception
    {
        public NoCustomerWithGiveIdException()
        {
        }

        public NoCustomerWithGiveIdException(string message) : base(message)
        {
        }

        public NoCustomerWithGiveIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
