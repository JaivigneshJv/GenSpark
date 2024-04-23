using System;

namespace ClinicManagementBLLibrary.Exceptions
{
    public class DoctorNotFoundException : ClinicManagementException
    {
        public DoctorNotFoundException() : base("Doctor not found.") { }
        public DoctorNotFoundException(int id) : base($"Doctor with ID {id} not found.") { }
        public DoctorNotFoundException(string name) : base($"Doctor with name {name} not found.") { }
    }
}
