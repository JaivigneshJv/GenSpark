namespace HotelBookingSystemModelLibrary
{
    public class Room
    {
        public int Id { get; }
        public string Name { get; }
        public string Type { get; }
        public string Features { get; }
        public int OccupancyCapacity { get; }
        public decimal NightlyRate { get; }
        public bool IsAvailable { get; private set; }
        public List<Reservation> Reservations { get; }

        public Room(int id, string name, string type, string features, int occupancyCapacity, decimal nightlyRate)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Features = features ?? throw new ArgumentNullException(nameof(features));
            OccupancyCapacity = occupancyCapacity;
            NightlyRate = nightlyRate;
            IsAvailable = true;
            Reservations = new List<Reservation>();
        }

        public void Book()
        {
            IsAvailable = false;
        }
        
        public void CancelBooking()
        {
            IsAvailable = true;
        }
    }
}
