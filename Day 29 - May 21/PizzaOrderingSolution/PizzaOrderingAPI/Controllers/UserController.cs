using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaOrderingAPI.Exceptions;
using PizzaOrderingAPI.Interfaces;
using PizzaOrderingAPI.Models.DTOs;

namespace PizzaOrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _logger = logger;
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
                Response.Cookies.Append("jwt-token-pizza-app", result.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, //prod
                    Expires = DateTime.UtcNow.AddMinutes(5) 
                });

                return Ok(new { Message = "Logged in successfully", result.Token });

            }
            catch (UnauthorizedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                _logger.LogCritical(ex.Message); //Logger
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
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

        [HttpPost("set-admin-access")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GrantAdminAccess([FromBody] int userId)
        {
            try
            {
                await _userService.GrantAdminAccess(userId);
                return Ok("User " + userId + " has admin access now!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    try
        //    {
        //        await _userService.DeleteUser(id);
        //        return NoContent();
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
    }
}
