using System;

namespace ClinicManagementBLLibrary.Exceptions
{
    public class DoctorAvailabilityException : ClinicManagementException
    {
        public DoctorAvailabilityException(string message) : base(message) { }
    }
}
