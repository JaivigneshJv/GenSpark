namespace HotelBookingSystemModelLibrary
{
    public class Guest
    {
        public int Id { get; }
        public string Name { get; }
        public string Contact { get; }
        public string Email { get; }
        public List<Reservation> Reservations { get; }
        public List<string> Preferences { get; }

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
