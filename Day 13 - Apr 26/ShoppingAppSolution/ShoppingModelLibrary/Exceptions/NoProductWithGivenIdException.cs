using System.Diagnostics.CodeAnalysis;


namespace ShoppingModelLibrary.Exceptions
{
    public class NoProductWithGivenIdException : Exception
    {
        string message;
        public NoProductWithGivenIdException()
        {
            message = "Product with the given Id is not present";
        }
        
        public override string Message => message;
    }
}
