using HotelBookingSystemDALLibrary;
using HotelBookingSystemModelLibrary;

namespace HotelBookingSystemBLLibrary
{
    public class LoginBL : ILoginService
    {
        private readonly LoginRepository _loginRepository;

        public LoginBL()
        {
            _loginRepository = new LoginRepository();
        }

        public LoginBL(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Login GetByUsername(string username)
        {
            return _loginRepository.GetByUsername(username) ?? throw new ArgumentNullException(nameof(username));
        }

        public void AddLogin(Login login)
        {
            _loginRepository.Add(login);
        }

        public void UpdateLogin(Login login)
        {
            _loginRepository.Update(login);
        }

        public void DeleteLogin(string username)
        {
            _loginRepository.Delete(username);
        }
    }
}
