namespace ClinicManagementAPI.Exceptions
{
    public class NoDoctorsFoundException : Exception
    {
        public NoDoctorsFoundException() : base("No doctors found.")
        {
        }
    }
}
