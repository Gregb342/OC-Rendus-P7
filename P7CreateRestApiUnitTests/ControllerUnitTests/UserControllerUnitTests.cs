using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using P7CreateRestApi.Services.Interfaces;

namespace P7CreateRestApiUnitTests.ControllerUnitTests
{
    public class UserControllerUnitTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly UserController _userController;

        public UserControllerUnitTests()
        {
            _mockUserService = new Mock<IUserService>();
            _userController = new UserController(_mockUserService.Object);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange
            var users = new List<ApplicationUser> { new ApplicationUser { Id = "1", UserName = "TestUser" } };
            _mockUserService.Setup(service => service.GetAllUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _userController.GetAllUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(users, okResult.Value);
        }

        [Fact]
        public async Task GetUserById_ValidId_ReturnsOkResult_WithUser()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", UserName = "TestUser" };
            _mockUserService.Setup(service => service.GetUserByIdAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _userController.GetUserById("1");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user, okResult.Value);
        }

        [Fact]
        public async Task GetUserById_InvalidId_ReturnsBadRequest()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _userController.GetUserById("abc"));
        }

        [Fact]
        public async Task GetUserById_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            _mockUserService.Setup(service => service.GetUserByIdAsync(1)).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _userController.GetUserById("1");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task CreateUser_ValidUser_ReturnsOk()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", UserName = "NewUser" };
            _mockUserService.Setup(service => service.CreateUserAsync(user)).Returns(Task.CompletedTask);

            // Act
            var result = await _userController.CreateUser(user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Utilisateur créé avec succès", okResult.Value);
        }

        [Fact]
        public async Task UpdateUser_ValidUser_ReturnsOk_WithUpdatedUser()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", UserName = "UpdatedUser" };
            _mockUserService.Setup(service => service.UpdateUserAsync(user)).ReturnsAsync(user);

            // Act
            var result = await _userController.UpdateUser("1", user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user, okResult.Value);
        }

        [Fact]
        public async Task UpdateUser_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", UserName = "UserNotFound" };
            _mockUserService.Setup(service => service.UpdateUserAsync(user)).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _userController.UpdateUser("1", user);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DeleteUser_ValidId_ReturnsOk()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1" };
            _mockUserService.Setup(service => service.DeleteUserAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _userController.DeleteUser(user);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteUser_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            var user = new ApplicationUser { Id = "abc" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _userController.DeleteUser(user));
        }
    }
}
