using System;

namespace HotelBookingSystemModelLibrary
{
    public class Reservation
    {
        public int Id { get; }
        public int RoomId { get; }
        public int GuestId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public decimal TotalCost { get; }
        public string CancellationPolicy { get; }
        public string Status { get; private set; } 

        public Reservation(int id, int roomId, int guestId, DateTime checkInDate, DateTime checkOutDate, decimal totalCost, string cancellationPolicy)
        {
            Id = id;
            RoomId = roomId;
            GuestId = guestId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            TotalCost = totalCost;
            CancellationPolicy = cancellationPolicy ?? throw new ArgumentNullException(nameof(cancellationPolicy));
            Status = "Pending";
        }

        public void Confirm()
        {
            Status = "Confirmed";
        }

        public void Cancel()
        {
            Status = "Cancelled";
        }
    }
}
