using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.CurvePoints;

namespace P7CreateRestApiUnitTests.ControllerUnitTests
{
    public class CurvePointControllerUnitTests
    {
        private readonly Mock<ICurvePointService> _mockService;
        private readonly CurvePointController _controller;

        public CurvePointControllerUnitTests()
        {
            _mockService = new Mock<ICurvePointService>();
            _controller = new CurvePointController(_mockService.Object);
        }

        [Fact]
        public async Task AddCurvePoint_ValidModel_ReturnsOk()
        {
            // ARRANGE
            var model = new AddCurvePointViewModel { CurveId = 1, AsOfDate = DateTime.UtcNow, Term = 5, CurvePointValue = 100 };

            // ACT
            var result = await _controller.AddCurvePoint(model);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCurvePoint = Assert.IsType<CurvePoint>(okResult.Value);
            Assert.Equal(model.CurveId, returnedCurvePoint.CurveId);
        }

        [Fact]
        public async Task AddCurvePoint_InvalidModel_ReturnsBadRequest()
        {
            // ARRANGE
            _controller.ModelState.AddModelError("CurveId", "Required");
            var model = new AddCurvePointViewModel();

            // ACT
            var result = await _controller.AddCurvePoint(model);

            // ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetCurvePoint_ExistingId_ReturnsOk()
        {
            // ARRANGE
            var cp = new GetCurvePointViewModel
            {
                CurveId = 1,
                AsOfDate = DateTime.UtcNow,
                Term = 5,
                CurvePointValue = 100
            };
            _mockService.Setup(s => s.GetCurvePointByIdAsync(1)).ReturnsAsync(cp);

            // ACT
            var result = await _controller.GetCurvePoint(1);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCurvePoint = Assert.IsType<GetCurvePointViewModel>(okResult.Value);
            Assert.Equal(cp.Id, returnedCurvePoint.Id);
            Assert.Equal(cp.CurveId, returnedCurvePoint.CurveId);
        }


        [Fact]
        public async Task GetAllCurvePoints_ReturnsOk()
        {
            // ARRANGE
            var list = new List<GetCurvePointViewModel> { new GetCurvePointViewModel { CurveId = 1 }, new GetCurvePointViewModel { CurveId = 2 } };
            _mockService.Setup(s => s.GetAllCurvePoints()).ReturnsAsync(list);

            // ACT
            var result = await _controller.GetAllCurvePoints();

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedList = Assert.IsType<List<GetCurvePointViewModel>>(okResult.Value);
            Assert.Equal(2, returnedList.Count);
        }

        [Fact]
        public async Task UpdateCurvePoint_ValidModel_ReturnsOk()
        {
            // ARRANGE
            var model = new UpdateCurvePointViewModel { Id = 1, CurveId = 2, Term = 10, CurvePointValue = 200 };
            var updatedCp = new GetCurvePointViewModel { CurveId = 2, Term = 10, CurvePointValue = 200 };
            _mockService.Setup(s => s.UpdateCurvePoint(model)).ReturnsAsync(updatedCp);

            // ACT
            var result = await _controller.UpdateCurvePoint(1, model);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCp = Assert.IsType<GetCurvePointViewModel>(okResult.Value);
            Assert.Equal(updatedCp.Id, returnedCp.Id);
        }

        [Fact]
        public async Task UpdateCurvePoint_MismatchedId_ReturnsBadRequest()
        {
            // ARRANGE
            var model = new UpdateCurvePointViewModel { Id = 2 };

            // ACT
            var result = await _controller.UpdateCurvePoint(1, model);

            // ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteCurvePoint_ValidId_ReturnsOk()
        {
            // ARRANGE
            _mockService.Setup(s => s.RemoveCurvePoint(1)).Returns(Task.CompletedTask);

            // ACT
            var result = await _controller.DeleteCurvePoint(1);

            // ASSERT
            Assert.IsType<OkResult>(result);
        }
    }
}

