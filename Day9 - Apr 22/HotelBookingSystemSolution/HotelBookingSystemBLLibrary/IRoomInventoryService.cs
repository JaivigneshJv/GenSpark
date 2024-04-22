using HotelBookingSystemModelLibrary;
namespace HotelBookingSystemBLLibrary
{
    public interface IRoomInventoryService
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int id);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int id);
    }
}
