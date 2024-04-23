using System;

namespace ClinicManagementBLLibrary.Exceptions
{
    public class AppointmentConflictException : ClinicManagementException
    {
        public AppointmentConflictException(string message) : base(message) { }
    }
}
