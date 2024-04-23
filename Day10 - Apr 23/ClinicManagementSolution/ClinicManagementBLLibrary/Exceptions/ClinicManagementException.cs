using System;

namespace ClinicManagementBLLibrary.Exceptions
{
    public class ClinicManagementException : Exception
    {
        public ClinicManagementException(string message) : base(message) { }
    }
}
