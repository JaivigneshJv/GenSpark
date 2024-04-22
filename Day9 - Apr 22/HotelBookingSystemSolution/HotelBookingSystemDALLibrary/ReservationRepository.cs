using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystemModelLibrary
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private List<Reservation> _reservations;

        public ReservationRepository()
        {
            _reservations = new List<Reservation>();
        }

        public Reservation GetById(int id)
        {
            return _reservations.FirstOrDefault(r => r.Id == id) ?? throw new ArgumentException($"Reservation with ID {id} not found."); 
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _reservations;
        }

        public void Add(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            _reservations.Add(reservation);
        }

        public void Update(Reservation reservation)
        {
            var existingReservation = GetById(reservation.Id);
            if (existingReservation != null)
            {
                existingReservation.CheckInDate = reservation.CheckInDate;
                existingReservation.CheckOutDate = reservation.CheckOutDate;
                existingReservation.TotalCost = reservation.TotalCost;
                existingReservation.CancellationPolicy = reservation.CancellationPolicy;
                existingReservation.Status = reservation.Status;
            }
            else
            {
                throw new ArgumentException($"Reservation with ID {reservation.Id} not found.");
            }
        }

        public void Delete(int id)
        {
            var reservationToRemove = GetById(id);
            if (reservationToRemove != null)
                _reservations.Remove(reservationToRemove);
        }
    }
}
