using PizzaOrderingAPI.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaOrderingAPI.Interfaces
{
    public interface IUserService
    {
        Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        Task<UserDTO> Register(UserRegisterDto userDto, string password);
        Task<UserDTO> GetUserById(int id);
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> UpdateUser(int id, UserRegisterDto updatedUserDto);
        Task DeleteUser(int id);
        Task GrantAdminAccess(int userId);
    }
}
