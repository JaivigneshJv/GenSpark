using HotelBookingSystemModelLibrary;

namespace HotelBookingSystemBLLibrary
{
    public interface ILoginService
    {
        Login GetByUsername(string username);
        void AddLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(string username);
    }
}
