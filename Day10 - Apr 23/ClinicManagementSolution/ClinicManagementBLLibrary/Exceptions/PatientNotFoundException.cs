using System;

namespace ClinicManagementBLLibrary.Exceptions
{
    public class PatientNotFoundException : ClinicManagementException
    {
        public PatientNotFoundException() : base("Patient not found.") { }
        public PatientNotFoundException(int id) : base($"Patient with ID {id} not found.") { }
        public PatientNotFoundException(string name) : base($"Patient with name {name} not found.") { }
    }
}
