using System.Runtime.Serialization;

namespace PizzaOrderingAPI.Exceptions
{
    [Serializable]
    internal class UserAlreadyHasAdminAccess : Exception
    {
        public UserAlreadyHasAdminAccess()
        {
        }

        public UserAlreadyHasAdminAccess(string? message) : base(message)
        {
        }

        public UserAlreadyHasAdminAccess(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserAlreadyHasAdminAccess(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}