namespace HotelBookingSystemModelLibrary
{
    public class RoomInventoryRepository : IRepository<Room>
    {
        private List<Room> _rooms;

        public RoomInventoryRepository()
        {
            _rooms = new List<Room>();
        }

        public Room GetById(int id)
        {
            return _rooms.FirstOrDefault(r => r.Id == id) ?? throw new ArgumentException($"Room with ID {id} not found."); ;
        }

        public IEnumerable<Room> GetAll()
        {
            return _rooms;
        }

        public void Add(Room room)
        {
            if (room == null)
                throw new ArgumentNullException(nameof(room));

            _rooms.Add(room);
        }

        public void Update(Room room)
        {
            var existingRoom = GetById(room.Id);
            if (existingRoom != null)
            {
                existingRoom.Name = room.Name;
                existingRoom.Type = room.Type;
                existingRoom.Features = room.Features;
                existingRoom.OccupancyCapacity = room.OccupancyCapacity;
                existingRoom.NightlyRate = room.NightlyRate;
                existingRoom.IsAvailable = room.IsAvailable;
            }
            else
            {
                throw new ArgumentException($"Room with ID {room.Id} not found.");
            }
        }

        public void Delete(int id)
        {
            var roomToRemove = GetById(id);
            if (roomToRemove != null)
                _rooms.Remove(roomToRemove);
        }
    }
}
