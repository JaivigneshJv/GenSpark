using PizzaOrderingAPI.Models;

namespace PizzaOrderingAPI.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        Task<User> UpdateUser(int id, User updatedUser);
    }
}
