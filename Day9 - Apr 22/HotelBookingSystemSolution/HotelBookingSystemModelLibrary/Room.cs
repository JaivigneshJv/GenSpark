namespace HotelBookingSystemModelLibrary
{
    public class Room
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Features { get; set; }
        public int OccupancyCapacity { get; set; }
        public decimal NightlyRate { get; set; }
        public bool IsAvailable { get; set; }

        public Room(int id, string name, string type, string features, int occupancyCapacity, decimal nightlyRate)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Features = features ?? throw new ArgumentNullException(nameof(features));
            OccupancyCapacity = occupancyCapacity;
            NightlyRate = nightlyRate;
            IsAvailable = true;
        }

    }
}
