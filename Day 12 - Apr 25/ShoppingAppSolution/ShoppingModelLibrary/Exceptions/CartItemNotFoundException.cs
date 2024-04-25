namespace ShoppingModelLibrary.Exceptions
{

    public class CartItemNotFoundException : Exception
    {
        string message;
        public CartItemNotFoundException()
        {
            message = "Cart Item with the given Id is not present";
        }

        public override string Message => message;
    }
}
