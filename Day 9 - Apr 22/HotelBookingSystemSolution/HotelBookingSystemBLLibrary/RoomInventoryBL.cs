using HotelBookingSystemModelLibrary;
namespace HotelBookingSystemBLLibrary
{
    public class RoomInventoryBL : IRoomInventoryService
    {
        private readonly IRepository<Room> _roomRepository;

        public RoomInventoryBL(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }

        /// <summary>
        /// Retrieves all rooms.
        /// </summary>
        /// <returns>A collection of all rooms.</returns>
        public IEnumerable<Room> GetAllRooms()
        {
            return _roomRepository.GetAll();
        }

        /// <summary>
        /// Retrieves a room by its ID.
        /// </summary>
        /// <param name="id">The ID of the room.</param>
        /// <returns>The room with the specified ID.</returns>
        public Room GetRoomById(int id)
        {
            return _roomRepository.GetById(id);
        }

        /// <summary>
        /// Adds a new room.
        /// </summary>
        /// <param name="room">The room to add.</param>
        public void AddRoom(Room room)
        {
            _roomRepository.Add(room);
        }

        /// <summary>
        /// Updates an existing room.
        /// </summary>
        /// <param name="room">The room to update.</param>
        public void UpdateRoom(Room room)
        {
            _roomRepository.Update(room);
        }

        /// <summary>
        /// Deletes a room by its ID.
        /// </summary>
        /// <param name="id">The ID of the room to delete.</param>
        public void DeleteRoom(int id)
        {
            _roomRepository.Delete(id);
        }
    }
}
