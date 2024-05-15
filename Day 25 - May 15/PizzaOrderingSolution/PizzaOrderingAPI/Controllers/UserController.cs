using Microsoft.AspNetCore.Mvc;
using PizzaOrderingAPI.Exceptions;
using PizzaOrderingAPI.Interfaces;
using PizzaOrderingAPI.Models;
using PizzaOrderingAPI.Models.DTOs;

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
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            var user = new User
            {
                Username = userDto.Username
            };

            await _userService.Register(user,userDto.Password);

            return Ok(new { Message = "Registred Successfully",userID = user.Id,userName=user.Username });
            //return Ok("Registered Succesfully");
            //return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO userDto)
        {
            var user = await _userService.Login(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { Message = "Logged In Successfully", userID = user.Id, userName = user.Username });
            //return Ok("Logged In Succesfully");
            //return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
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
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            try
            {
                await _userService.UpdateUser(id, user);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        
    }
}

