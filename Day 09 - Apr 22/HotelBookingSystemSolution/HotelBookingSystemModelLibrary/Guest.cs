namespace HotelBookingSystemModelLibrary
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<string> Preferences { get; set; }

        public Guest(int id, string name, string contact, string email)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Reservations = new List<Reservation>();
            Preferences = new List<string>();
        }
    }
}
