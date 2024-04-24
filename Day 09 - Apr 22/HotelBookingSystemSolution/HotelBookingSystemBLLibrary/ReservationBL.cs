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

        /// <summary>
        /// Retrieves all reservations.
        /// </summary>
        /// <returns>A collection of Reservation objects.</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAll();
        }

        /// <summary>
        /// Retrieves a reservation by its ID.
        /// </summary>
        /// <param name="id">The ID of the reservation.</param>
        /// <returns>The Reservation object with the specified ID.</returns>
        public Reservation GetReservationById(int id)
        {
            return _reservationRepository.GetById(id);
        }

        /// <summary>
        /// Adds a new reservation.
        /// </summary>
        /// <param name="reservation">The Reservation object to add.</param>
        public void AddReservation(Reservation reservation)
        {
            _reservationRepository.Add(reservation);
        }

        /// <summary>
        /// Updates an existing reservation.
        /// </summary>
        /// <param name="reservation">The Reservation object to update.</param>
        public void UpdateReservation(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }

        /// <summary>
        /// Cancels a reservation by its ID.
        /// </summary>
        /// <param name="id">The ID of the reservation to cancel.</param>
        public void CancelReservation(int id)
        {
            _reservationRepository.Delete(id);
        }
    }
}
