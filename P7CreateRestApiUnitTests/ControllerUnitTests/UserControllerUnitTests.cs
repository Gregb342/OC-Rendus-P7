using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApiUnitTests.ControllerUnitTests
{
    public class UserControllerUnitTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly UserController _controller;

        public UserControllerUnitTests()
        {
            _userManagerMock = MockUserManager();
            _controller = new UserController(_userManagerMock.Object);
        }

        private static Mock<UserManager<ApplicationUser>> MockUserManager()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                store.Object, null, null, null, null, null, null, null, null);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsOk_WhenUsersExist()
        {
            // Arrange
            var users = new List<ApplicationUser>
        {
            new ApplicationUser { Id = "1", UserName = "User1", Email = "user1@test.com" },
            new ApplicationUser { Id = "2", UserName = "User2", Email = "user2@test.com" }
        };
            _userManagerMock.Setup(um => um.Users).Returns(users.AsQueryable());

            // Act
            var result = await _controller.GetAllUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUsers = Assert.IsType<List<ApplicationUser>>(okResult.Value);
            Assert.Equal(2, returnedUsers.Count);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsNotFound_WhenNoUsersExist()
        {
            // Arrange
            _userManagerMock.Setup(um => um.Users).Returns(Enumerable.Empty<ApplicationUser>().AsQueryable());

            // Act
            var result = await _controller.GetAllUsers();

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task GetUserById_ReturnsOk_WhenUserExists()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", UserName = "User1" };
            _userManagerMock.Setup(um => um.FindByIdAsync("1")).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUserById("1");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user, okResult.Value);
        }

        [Fact]
        public async Task GetUserById_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            _userManagerMock.Setup(um => um.FindByIdAsync("1")).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _controller.GetUserById("1");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task CreateUser_ReturnsOk_WhenUserIsCreated()
        {
            // Arrange
            var model = new RegisterModel { Email = "test@test.com", Password = "P@ssword1" };
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<ApplicationUser>(), model.Password))
                            .ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), "User"))
                            .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.CreateUser(model);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CreateUser_ReturnsBadRequest_WhenCreationFails()
        {
            // Arrange
            var model = new RegisterModel { Email = "test@test.com", Password = "P@ssword1" };
            _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<ApplicationUser>(), model.Password))
                            .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error" }));

            // Act
            var result = await _controller.CreateUser(model);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateUser_ReturnsOk_WhenUserIsUpdated()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", UserName = "UpdatedUser" };
            _userManagerMock.Setup(um => um.UpdateAsync(user)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.UpdateUser("1", user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal($"Utilisateur {user} mis à jour avec succés", okResult.Value);
        }

        [Fact]
        public async Task UpdateUser_ReturnsNotFound_WhenUserUpdateFails()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", UserName = "UpdatedUser" };
            var errors = new IdentityError[] { new IdentityError { Description = "Erreur de mise à jour" } };

            _userManagerMock.Setup(um => um.UpdateAsync(user)).ReturnsAsync(IdentityResult.Failed(errors));

            // Act
            var result = await _controller.UpdateUser("1", user);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var errorList = Assert.IsAssignableFrom<IEnumerable<IdentityError>>(notFoundResult.Value);

            Assert.Single(errorList);
            Assert.Equal("Erreur de mise à jour", errorList.First().Description);
        }


        [Fact]
        public async Task DeleteUser_ReturnsOk_WhenUserIsDeleted()
        {
            // Arrange
            var user = new ApplicationUser { Id = "1", UserName = "User1" };
            _userManagerMock.Setup(um => um.FindByIdAsync(user.Id)).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.DeleteUser(user.Id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }

}
