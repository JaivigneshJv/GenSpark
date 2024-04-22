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

        /// <summary>
        /// Retrieves a login by username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>The login object if found, otherwise throws an ArgumentNullException.</returns>
        public Login GetByUsername(string username)
        {
            return _loginRepository.GetByUsername(username) ?? throw new ArgumentNullException(nameof(username));
        }

        /// <summary>
        /// Adds a new login.
        /// </summary>
        /// <param name="login">The login object to add.</param>
        public void AddLogin(Login login)
        {
            _loginRepository.Add(login);
        }

        /// <summary>
        /// Updates an existing login.
        /// </summary>
        /// <param name="login">The login object to update.</param>
        public void UpdateLogin(Login login)
        {
            _loginRepository.Update(login);
        }

        /// <summary>
        /// Deletes a login by username.
        /// </summary>
        /// <param name="username">The username of the login to delete.</param>
        public void DeleteLogin(string username)
        {
            _loginRepository.Delete(username);
        }
    }
}
