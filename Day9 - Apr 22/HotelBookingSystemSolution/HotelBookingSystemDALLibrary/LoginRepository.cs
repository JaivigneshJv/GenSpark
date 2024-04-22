using HotelBookingSystemModelLibrary;
namespace HotelBookingSystemDALLibrary
{
    public class LoginRepository
    {
        private List<Login> _logins;

        public LoginRepository()
        {
            _logins = new List<Login>();
        }

        public Login? GetByUsername(string username)
        {
            return _logins.FirstOrDefault(l => l.Username == username);
        }

        public void Add(Login login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            _logins.Add(login);
        }

        public void Update(Login login)
        {
            var existingLogin = GetByUsername(login.Username!);
            if (existingLogin != null)
            {
                existingLogin.Password = login.Password;
                existingLogin.UserType = login.UserType;
            }
            else
            {
                throw new ArgumentException($"Login with username {login.Username} not found.");
            }
        }

        public void Delete(string username)
        {
            var loginToRemove = GetByUsername(username);
            if (loginToRemove != null)
                _logins.Remove(loginToRemove);
        }
    }
}
