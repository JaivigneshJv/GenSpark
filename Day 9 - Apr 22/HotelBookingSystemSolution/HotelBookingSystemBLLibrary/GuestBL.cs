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

        /// <summary>
        /// Retrieves all guests.
        /// </summary>
        /// <returns>A collection of all guests.</returns>
        public IEnumerable<Guest> GetAllGuests()
        {
            return _guestRepository.GetAll();
        }

        /// <summary>
        /// Retrieves a guest by their ID.
        /// </summary>
        /// <param name="id">The ID of the guest.</param>
        /// <returns>The guest with the specified ID.</returns>
        public Guest GetGuestById(int id)
        {
            return _guestRepository.GetById(id);
        }

        /// <summary>
        /// Adds a new guest.
        /// </summary>
        /// <param name="guest">The guest to add.</param>
        public void AddGuest(Guest guest)
        {
            _guestRepository.Add(guest);
        }

        /// <summary>
        /// Updates an existing guest.
        /// </summary>
        /// <param name="guest">The guest to update.</param>
        public void UpdateGuest(Guest guest)
        {
            _guestRepository.Update(guest);
        }

        /// <summary>
        /// Deletes a guest by their ID.
        /// </summary>
        /// <param name="id">The ID of the guest to delete.</param>
        public void DeleteGuest(int id)
        {
            _guestRepository.Delete(id);
        }
    }
}
