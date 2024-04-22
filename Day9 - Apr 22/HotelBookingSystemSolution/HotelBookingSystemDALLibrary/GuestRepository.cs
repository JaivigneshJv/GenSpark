namespace HotelBookingSystemModelLibrary
{
    public class GuestRepository : IRepository<Guest>
    {
        private List<Guest> _guests;

        public GuestRepository()
        {
            _guests = new List<Guest>();
        }

        public Guest GetById(int id)
        {
            return _guests.FirstOrDefault(g => g.Id == id) ?? throw new ArgumentException($"Guest with ID {id} not found."); 
        }

        public IEnumerable<Guest> GetAll()
        {
            return _guests;
        }

        public void Add(Guest guest)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest));

            _guests.Add(guest);
        }

        public void Update(Guest guest)
        {
            var existingGuest = GetById(guest.Id);
            if (existingGuest != null)
            {
                existingGuest.Name = guest.Name;
                existingGuest.Contact = guest.Contact;
                existingGuest.Email = guest.Email; 
            }
            else
            {
                throw new ArgumentException($"Guest with ID {guest.Id} not found.");
            }
        }

        public void Delete(int id)
        {
            var guestToRemove = GetById(id);
            if (guestToRemove != null)
                _guests.Remove(guestToRemove);
        }
    }
}
