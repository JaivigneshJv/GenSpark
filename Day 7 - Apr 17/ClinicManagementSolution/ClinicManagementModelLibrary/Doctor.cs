namespace ClinicManagementModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Specialty { get; set; } = string.Empty;
        public string? Contact { get; set; } = string.Empty;
        public int Availability { get; set; }

        public Doctor(string? name, string? specialty, string? contact, int availability)
        {
            //Id = -1;
            Name = name;
            Specialty = specialty;
            Contact = contact;
            Availability = availability;
        }
    }
}
