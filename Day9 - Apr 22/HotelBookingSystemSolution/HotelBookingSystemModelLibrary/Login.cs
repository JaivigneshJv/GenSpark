namespace HotelBookingSystemModelLibrary
{
    public class Login
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Guest,
        RoomOwner
    }
}
