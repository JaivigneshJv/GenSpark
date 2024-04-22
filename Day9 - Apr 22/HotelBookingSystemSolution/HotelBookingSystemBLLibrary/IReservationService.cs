using HotelBookingSystemModelLibrary;
namespace HotelBookingSystemBLLibrary
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        void AddReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void CancelReservation(int id);
    }
}
