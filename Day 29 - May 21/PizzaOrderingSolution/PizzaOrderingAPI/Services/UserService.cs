using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingAPI.Contexts;
using PizzaOrderingAPI.Exceptions;
using PizzaOrderingAPI.Interfaces;
using PizzaOrderingAPI.Models;
using PizzaOrderingAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaOrderingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly PizzaOrderingContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService(PizzaOrderingContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UserDTO> Register(UserRegisterDto userDto, string password)
        {
            if (await UserExists(userDto.Username))
                throw new UserAlreadyExistsException();

            var user = _mapper.Map<User>(userDto);

            using var hmac = new HMACSHA512();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            user.PasswordSalt = hmac.Key;
            user.Role = "User";

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == loginDTO.Username);

            if (user == null)
                throw new UserNotFoundException();

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            if (!computedHash.SequenceEqual(user.PasswordHash))
                throw new IncorrectPasswordException();

            var token = _tokenService.GenerateToken(user);

            return new LoginReturnDTO
            {
                UserId = user.Id,
                Token = token
            };
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> UpdateUser(int id, UserRegisterDto updatedUserDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            _mapper.Map(updatedUserDto, user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username);
        }
        public async Task GrantAdminAccess(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            if(user.Role == "Admin")
            {
                throw new UserAlreadyHasAdminAccess($"User {user.Id} has admin access already");
            }
            user.Role = "Admin";
            await _context.SaveChangesAsync();
        }
    }
}
