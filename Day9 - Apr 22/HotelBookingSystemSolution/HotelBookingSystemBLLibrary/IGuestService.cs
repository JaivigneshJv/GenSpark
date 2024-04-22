using HotelBookingSystemModelLibrary;
namespace HotelBookingSystemBLLibrary
{
    public interface IGuestService
    {
        IEnumerable<Guest> GetAllGuests();
        Guest GetGuestById(int id);
        void AddGuest(Guest guest);
        void UpdateGuest(Guest guest);
        void DeleteGuest(int id);
    }
}
