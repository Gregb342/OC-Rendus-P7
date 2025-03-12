using Dot.Net.WebApi.Domain;
using Moq;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services;
using P7CreateRestApi.ViewsModels.CurvePoints;

namespace P7CreateRestApiUnitTests.ServiceUnitTests
{
    public class CurvePointServiceUnitTests
    {
        private readonly Mock<ICurvePointRepository> _curvePointRepositoryMock;
        private readonly CurvePointService _curvePointService;

        public CurvePointServiceUnitTests()
        {
            _curvePointRepositoryMock = new Mock<ICurvePointRepository>();
            _curvePointService = new CurvePointService(_curvePointRepositoryMock.Object);
        }

        [Fact]
        public async Task AddCurvePoint_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var curvePoint = new CurvePoint { Id = 1, CurveId = 100, Term = 2.5, CurvePointValue = 10.0, AsOfDate = DateTime.Now, CreationDate = DateTime.Now };

            // Act
            await _curvePointService.AddCurvePoint(curvePoint);

            // Assert
            _curvePointRepositoryMock.Verify(repo => repo.AddAsync(curvePoint), Times.Once);
        }

        [Fact]
        public async Task GetAllCurvePoints_ShouldReturnMappedViewModels()
        {
            // Arrange
            var curvePoints = new List<CurvePoint>
            {
                new CurvePoint { Id = 1, CurveId = 100, Term = 2.5, CurvePointValue = 10.0, AsOfDate = DateTime.Now, CreationDate = DateTime.Now },
                new CurvePoint { Id = 2, CurveId = 200, Term = 3.5, CurvePointValue = 20.0, AsOfDate = DateTime.Now, CreationDate = DateTime.Now }
            };

            _curvePointRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(curvePoints);

            // Act
            var result = await _curvePointService.GetAllCurvePoints();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(10.0, result[0].CurvePointValue);
        }

        [Fact]
        public async Task GetCurvePointByIdAsync_ShouldReturnCurvePoint_WhenExists()
        {
            // Arrange
            var curvePoint = new CurvePoint { Id = 1, CurveId = 100, Term = 2.5, CurvePointValue = 10.0, AsOfDate = DateTime.Now, CreationDate = DateTime.Now };
            _curvePointRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(curvePoint);

            // Act
            var result = await _curvePointService.GetCurvePointByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetCurvePointByIdAsync_ShouldThrowKeyNotFoundException_WhenNotFound()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CurvePoint)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _curvePointService.GetCurvePointByIdAsync(1));
            Assert.Equal("Le CurvePoint avec l'ID 1 n'existe pas.", exception.Message);
        }

        [Fact]
        public async Task UpdateCurvePoint_ShouldUpdateAndReturnViewModel_WhenExists()
        {
            // Arrange
            var existingCurvePoint = new CurvePoint { Id = 1, CurveId = 100, Term = 2.5, CurvePointValue = 10.0, AsOfDate = DateTime.Now, CreationDate = DateTime.Now };
            var updateModel = new UpdateCurvePointViewModel { Id = 1, CurveId = 200, Term = 3.0, CurvePointValue = 15.0, AsOfDate = DateTime.Now, CreationDate = DateTime.Now };

            _curvePointRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingCurvePoint);

            // Act
            var result = await _curvePointService.UpdateCurvePoint(updateModel);

            // Assert
            _curvePointRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<CurvePoint>(cp =>
                cp.Id == 1 &&
                cp.CurveId == 200 &&
                cp.Term == 3.0 &&
                cp.CurvePointValue == 15.0)), Times.Once);

            Assert.Equal(15.0, result.CurvePointValue);
        }

        [Fact]
        public async Task UpdateCurvePoint_ShouldThrowKeyNotFoundException_WhenNotFound()
        {
            // Arrange
            var updateModel = new UpdateCurvePointViewModel { Id = 1, CurveId = 200, Term = 3.0, CurvePointValue = 15.0, AsOfDate = DateTime.Now, CreationDate = DateTime.Now };
            _curvePointRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CurvePoint)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _curvePointService.UpdateCurvePoint(updateModel));
            Assert.Equal("Le CurvePoint avec l'ID 1 n'existe pas.", exception.Message);
        }

        [Fact]
        public async Task RemoveCurvePoint_ShouldCallRepositoryDeleteAsync_WhenExists()
        {
            // Arrange
            var curvePoint = new CurvePoint { Id = 1 };
            _curvePointRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(curvePoint);

            // Act
            await _curvePointService.RemoveCurvePoint(1);

            // Assert
            _curvePointRepositoryMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task RemoveCurvePoint_ShouldThrowKeyNotFoundException_WhenNotFound()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CurvePoint)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _curvePointService.RemoveCurvePoint(1));
            Assert.Equal("Le CurvePoint avec l'ID 1 n'existe pas.", exception.Message);
        }
    }
}
