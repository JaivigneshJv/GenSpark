using Microsoft.AspNetCore.Mvc;
using PizzaOrderingAPI.Exceptions;
using PizzaOrderingAPI.Interfaces;
using PizzaOrderingAPI.Models.DTOs;
using System.Threading.Tasks;

namespace PizzaOrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(UserRegisterDto userDto)
        {
            var user = await _userService.Register(userDto, userDto.Password);
            return Ok(new { Message = "Registered Successfully", UserID = user.Id, UserName = user.Username });
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO userDto)
        {
            try
            {
                var result = await _userService.Login(userDto);
                return Ok(result);
            }
            catch (UnauthorizedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int id, UserRegisterDto updatedUserDto)
        {
            try
            {
                var user = await _userService.UpdateUser(id, updatedUserDto);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
