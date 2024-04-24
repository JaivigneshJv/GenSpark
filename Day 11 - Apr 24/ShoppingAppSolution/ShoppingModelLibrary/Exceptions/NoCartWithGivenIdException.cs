using System;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartWithGivenIdException : Exception
    {
        public NoCartWithGivenIdException(int cartId) : base($"Cart with ID {cartId} does not exist.")
        {
        }
    }
}
