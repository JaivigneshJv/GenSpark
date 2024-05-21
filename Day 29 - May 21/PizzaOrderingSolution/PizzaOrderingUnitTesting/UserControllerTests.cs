using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using PizzaOrderingAPI.Controllers;
using PizzaOrderingAPI.Interfaces;
using PizzaOrderingAPI.Models.DTOs;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PizzaOrderingAPITests
{
    public class UserControllerTests
    {
        private Mock<IUserService> _userServiceMock;
        private Mock<ILogger<UserController>> _loggerMock;
        private UserController _userController;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _loggerMock = new Mock<ILogger<UserController>>();
            _userController = new UserController(_userServiceMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task Register_ShouldReturnOkResult_WhenUserIsRegisteredSuccessfully()
        {
            // Arrange
            var userDto = new UserRegisterDto { Username = "test", Password = "password" };
            var user = new UserDTO { Id = 1, Username = "test" };
            _userServiceMock.Setup(s => s.Register(userDto, userDto.Password)).ReturnsAsync(user);

            // Act
            var result = await _userController.Register(userDto);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task Login_ShouldReturnOkResult_WhenUserIsLoggedInSuccessfully()
        {
            // Arrange
            var userDto = new UserLoginDTO { Username = "test", Password = "password" };
            var loginReturnDto = new LoginReturnDTO { Token = "token" };
            _userServiceMock.Setup(s => s.Login(userDto)).ReturnsAsync(loginReturnDto);

            // Act
            var result = await _userController.Login(userDto);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }
        [Test]
        public async Task GetUserById_ShouldReturnOkResult_WhenUserExists()
        {
            // Arrange
            var user = new UserDTO { Id = 1, Username = "test" };
            _userServiceMock.Setup(s => s.GetUserById(1)).ReturnsAsync(user);

            // Act
            var result = await _userController.GetUserById(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetAllUsers_ShouldReturnOkResult_WhenUsersExist()
        {
            // Arrange
            var users = new List<UserDTO> { new UserDTO { Id = 1, Username = "test" } };
            _userServiceMock.Setup(s => s.GetAllUsers()).ReturnsAsync(users);

            // Act
            var result = await _userController.GetAllUsers();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task UpdateUser_ShouldReturnOkResult_WhenUserIsUpdatedSuccessfully()
        {
            // Arrange
            var userDto = new UserRegisterDto { Username = "test", Password = "password" };
            var user = new UserDTO { Id = 1, Username = "test" };
            _userServiceMock.Setup(s => s.UpdateUser(1, userDto)).ReturnsAsync(user);

            // Act
            var result = await _userController.UpdateUser(1, userDto);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GrantAdminAccess_ShouldReturnOkResult_WhenAdminAccessIsGrantedSuccessfully()
        {
            // Arrange
            _userServiceMock.Setup(s => s.GrantAdminAccess(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _userController.GrantAdminAccess(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

    }
}
