using HotelBookingSystemModelLibrary;
namespace HotelBookingSystemBLLibrary
{
    public class ReservationBL : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationBL(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAll();
        }

        public Reservation GetReservationById(int id)
        {
            return _reservationRepository.GetById(id);
        }

        public void AddReservation(Reservation reservation)
        {
            _reservationRepository.Add(reservation);
        }

        public void UpdateReservation(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }

        public void CancelReservation(int id)
        {
            _reservationRepository.Delete(id);
        }
    }
}
