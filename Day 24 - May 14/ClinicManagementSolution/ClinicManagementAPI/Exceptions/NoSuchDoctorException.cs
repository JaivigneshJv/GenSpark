namespace ClinicManagementAPI.Exceptions
{
    public class NoSuchDoctorException : Exception
    {
        public NoSuchDoctorException() : base("No such doctor found.")
        {
        }
    }
}
