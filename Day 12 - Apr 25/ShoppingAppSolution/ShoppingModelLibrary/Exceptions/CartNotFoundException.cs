

namespace ShoppingModelLibrary.Exceptions
{
    public class CartNotFoundException  : Exception
    {
        string message;

        public CartNotFoundException()
        {
            message = "Cart with the given Id is not present";
        }
        public override string Message => message;
    }
}
