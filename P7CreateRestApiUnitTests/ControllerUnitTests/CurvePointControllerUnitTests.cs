//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using P7CreateRestApi.Services.Interfaces;
//using P7CreateRestApi.ViewsModels.CurvePoints;
//using Dot.Net.WebApi.Domain;
//using Dot.Net.WebApi.Controllers;

//namespace P7CreateRestApiUnitTests.ControllerUnitTests
//{
//    public class CurvePointControllerUnitTests
//    {
//        private readonly Mock<ICurvePointService> _mockService;
//        private readonly CurvePointController _controller;

//        public CurvePointControllerTests()
//        {
//            _mockService = new Mock<ICurvePointService>();
//            _controller = new CurvePointController(_mockService.Object);
//        }

//        [Fact]
//        public async Task AddCurvePoint_ValidModel_ReturnsOk()
//        {
//            var model = new AddCurvePointViewModel { CurveId = 1, AsOfDate = DateTime.UtcNow, Term = 5, CurvePointValue = 100 };

//            var result = await _controller.AddCurvePoint(model);

//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedCurvePoint = Assert.IsType<CurvePoint>(okResult.Value);
//            Assert.Equal(model.CurveId, returnedCurvePoint.CurveId);
//        }

//        [Fact]
//        public async Task AddCurvePoint_InvalidModel_ReturnsBadRequest()
//        {
//            _controller.ModelState.AddModelError("CurveId", "Required");
//            var model = new AddCurvePointViewModel();

//            var result = await _controller.AddCurvePoint(model);

//            Assert.IsType<BadRequestObjectResult>(result);
//        }

//        [Fact]
//        public async Task GetCurvePoint_ExistingId_ReturnsOk()
//        {
//            var cp = new CurvePoint { CurveId = 1, AsOfDate = DateTime.UtcNow, Term = 5, CurvePointValue = 100 };
//            _mockService.Setup(s => s.GetCurvePointByIdAsync(1)).ReturnsAsync(cp);

//            var result = await _controller.GetCurvePoint(1);

//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedCurvePoint = Assert.IsType<CurvePoint>(okResult.Value);
//            Assert.Equal(1, returnedCurvePoint.CurveId);
//        }

//        [Fact]
//        public async Task GetAllCurvePoints_ReturnsOk()
//        {
//            var list = new List<CurvePoint> { new CurvePoint { CurveId = 1 }, new CurvePoint { CurveId = 2 } };
//            _mockService.Setup(s => s.GetAllCurvePoints()).ReturnsAsync(list);

//            var result = await _controller.GetAllCurvePoints();

//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedList = Assert.IsType<List<CurvePoint>>(okResult.Value);
//            Assert.Equal(2, returnedList.Count);
//        }

//        [Fact]
//        public async Task UpdateCurvePoint_ValidModel_ReturnsOk()
//        {
//            var model = new UpdateCurvePointViewModel { Id = 1, CurveId = 2, Term = 10, CurvePointValue = 200 };
//            var updatedCp = new CurvePoint { CurveId = 2, Term = 10, CurvePointValue = 200 };
//            _mockService.Setup(s => s.UpdateCurvePoint(model)).ReturnsAsync(updatedCp);

//            var result = await _controller.UpdateCurvePoint(1, model);

//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedCp = Assert.IsType<CurvePoint>(okResult.Value);
//            Assert.Equal(2, returnedCp.CurveId);
//        }

//        [Fact]
//        public async Task UpdateCurvePoint_MismatchedId_ReturnsBadRequest()
//        {
//            var model = new UpdateCurvePointViewModel { Id = 2 };

//            var result = await _controller.UpdateCurvePoint(1, model);

//            Assert.IsType<BadRequestObjectResult>(result);
//        }

//        [Fact]
//        public async Task DeleteCurvePoint_ValidId_ReturnsOk()
//        {
//            _mockService.Setup(s => s.RemoveCurvePoint(1)).Returns(Task.CompletedTask);

//            var result = await _controller.DeleteCurvePoint(1);

//            Assert.IsType<OkResult>(result);
//        }
//    }
//}

