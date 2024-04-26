﻿

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartWithGivenIdException : Exception
    {
        string message;
        public NoCartWithGivenIdException()
        {
            message = "Cart with the given Id is not present";
        }

        public override string Message => message;
    }
}
