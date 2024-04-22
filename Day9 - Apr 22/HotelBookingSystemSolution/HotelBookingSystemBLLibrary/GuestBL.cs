using HotelBookingSystemModelLibrary;
namespace HotelBookingSystemBLLibrary
{
    public class GuestBL : IGuestService
    {
        private readonly IRepository<Guest> _guestRepository;

        public GuestBL(IRepository<Guest> guestRepository)
        {
            _guestRepository = guestRepository ?? throw new ArgumentNullException(nameof(guestRepository));
        }

        public IEnumerable<Guest> GetAllGuests()
        {
            return _guestRepository.GetAll();
        }

        public Guest GetGuestById(int id)
        {
            return _guestRepository.GetById(id);
        }

        public void AddGuest(Guest guest)
        {
            _guestRepository.Add(guest);
        }

        public void UpdateGuest(Guest guest)
        {
            _guestRepository.Update(guest);
        }

        public void DeleteGuest(int id)
        {
            _guestRepository.Delete(id);
        }
    }
}
