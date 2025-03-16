using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using P7CreateRestApi.Models;

namespace P7CreateRestApiUnitTests.ControllerUnitTests
{
    public class AuthControllerUnitTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<ILogger<AuthController>> _loggerMock;
        private readonly AuthController _authController;

        public AuthControllerUnitTests()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            var roleStoreMock = new Mock<IRoleStore<IdentityRole>>();
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(roleStoreMock.Object, null, null, null, null);

            _configurationMock = new Mock<IConfiguration>();
            _loggerMock = new Mock<ILogger<AuthController>>();

            _authController = new AuthController(
                _userManagerMock.Object,
                _roleManagerMock.Object,
                _configurationMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task Register_ShouldReturnOk_WhenUserIsCreated()
        {
            // Arrange
            var model = new RegisterModel { Email = "test@test.com", Password = "Password123!" };
            _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authController.Register(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Utilisateur créé avec succès !", okResult.Value);
        }

        [Fact]
        public async Task Register_ShouldReturnBadRequest_WhenUserCreationFails()
        {
            // Arrange
            var model = new RegisterModel { Email = "test@test.com", Password = "Password123!" };
            _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error" }));

            // Act
            var result = await _authController.Register(model);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Login_ShouldReturnUnauthorized_WhenUserNotFound()
        {
            // Arrange
            var model = new LoginModel { Email = "test@test.com", Password = "Password123!" };
            _userManagerMock.Setup(um => um.FindByNameAsync(model.Email)).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authController.Login(model);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Identifiants incorrects", unauthorizedResult.Value);
        }

        [Fact]
        public async Task AssignRole_ShouldReturnOk_WhenRoleIsAssigned()
        {
            // Arrange
            var model = new AssignRoleModel { Username = "testUser", Role = "Admin" };
            var user = new ApplicationUser { UserName = "testUser" };

            _userManagerMock.Setup(um => um.FindByNameAsync(model.Username)).ReturnsAsync(user);
            _roleManagerMock.Setup(rm => rm.RoleExistsAsync(model.Role)).ReturnsAsync(true);
            _userManagerMock.Setup(um => um.AddToRoleAsync(user, model.Role)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authController.AssignRole(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal($"Rôle '{model.Role}' assigné à {model.Username}", okResult.Value);
        }

        [Fact]
        public async Task GetRoles_ShouldReturnRoles_WhenUserExists()
        {
            // Arrange
            var username = "testUser";
            var user = new ApplicationUser { UserName = username };
            var roles = new List<string> { "Admin", "User" };

            _userManagerMock.Setup(um => um.FindByNameAsync(username)).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.GetRolesAsync(user)).ReturnsAsync(roles);

            // Act
            var result = await _authController.GetRoles(username);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(roles, okResult.Value);
        }
    }
}

