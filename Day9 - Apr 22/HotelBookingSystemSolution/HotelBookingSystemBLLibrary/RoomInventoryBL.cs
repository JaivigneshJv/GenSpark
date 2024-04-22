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

        public IEnumerable<Room> GetAllRooms()
        {
            return _roomRepository.GetAll();
        }

        public Room GetRoomById(int id)
        {
            return _roomRepository.GetById(id);
        }

        public void AddRoom(Room room)
        {
            _roomRepository.Add(room);
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.Update(room);
        }

        public void DeleteRoom(int id)
        {
            _roomRepository.Delete(id);
        }
    }
}
