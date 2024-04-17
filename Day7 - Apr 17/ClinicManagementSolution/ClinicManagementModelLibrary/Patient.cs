namespace ClinicManagementModelLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string? Contact { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;

        public Patient( string? name, DateTime dateOfBirth, string? contact, string? address)
        {
            //Id = -1;
            Name = name;
            DateOfBirth = dateOfBirth;
            Contact = contact;
            Address = address;
        }
    }
}
