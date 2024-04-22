namespace HotelBookingSystemModelLibrary
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalCost { get; set; }
        public string CancellationPolicy { get; set; }
        public string Status { get; set; } 

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
