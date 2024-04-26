

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartItemWithGivenIdException : Exception
    {
        string message;
        public NoCartItemWithGivenIdException()
        {
            message = "Cart Item with the given Id is not present";
        }

     
        public override string Message => message;
    }
}
