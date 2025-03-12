using Dot.Net.WebApi.Domain;
using Moq;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services;
namespace P7CreateRestApiUnitTests.ServiceUnitTests
{
    public class UserServiceUnitTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService _userService;

        public UserServiceUnitTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnUsers()
        {
            // Arrange
            var users = new List<ApplicationUser> { new ApplicationUser { Id = "1", Fullname = "John Doe" } };
            _userRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", Fullname = "John Doe" };
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Fullname);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldThrowKeyNotFoundException_WhenUserDoesNotExist()
        {
            // Arrange
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((ApplicationUser)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _userService.GetUserByIdAsync(1));
        }

        [Fact]
        public async Task CreateUserAsync_ShouldCallRepository()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", Fullname = "John Doe" };

            // Act
            await _userService.CreateUserAsync(user);

            // Assert
            _userRepositoryMock.Verify(repo => repo.AddAsync(user), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldReturnUpdatedUser_WhenUserExists()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", Fullname = "John Doe", Email = "john@example.com" };
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);
            _userRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<ApplicationUser>())).Returns(Task.CompletedTask);

            // Act
            var result = await _userService.UpdateUserAsync(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Fullname);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", Fullname = "John Doe" };
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _userService.UpdateUserAsync(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldThrowArgumentException_WhenUserIdIsInvalid()
        {
            // Arrange
            var user = new ApplicationUser { Id = "abc", Fullname = "John Doe" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _userService.UpdateUserAsync(user));
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldCallRepository_WhenUserExists()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", Fullname = "John Doe" };
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

            // Act
            await _userService.DeleteUserAsync(1);

            // Assert
            _userRepositoryMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldThrowKeyNotFoundException_WhenUserDoesNotExist()
        {
            // Arrange
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((ApplicationUser)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _userService.DeleteUserAsync(1));
        }
    }
}
