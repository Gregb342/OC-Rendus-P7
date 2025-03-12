using Microsoft.AspNetCore.Mvc;
using Moq;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Ratings;
using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Controllers.Domain;

namespace P7CreateRestApiUnitTests.ControllerUnitTests
{
    public class RatingControllerUnitTests
    {
        private readonly Mock<IRatingService> _mockService;
        private readonly RatingController _controller;

        public RatingControllerUnitTests()
        {
            _mockService = new Mock<IRatingService>();
            _controller = new RatingController(_mockService.Object);
        }

        [Fact]
        public async Task AddRating_ValidModel_ReturnsOk()
        {
            // ARRANGE
            var model = new AddRatingViewModel { MoodysRating = "A", SandPRating = "A", FitchRating = "A", OrderNumber = 1 };
            var rating = new Rating { MoodysRating = "A", SandPRating = "A", FitchRating = "A", OrderNumber = 1 };

            _mockService.Setup(s => s.AddRating(It.IsAny<Rating>())).Returns(Task.CompletedTask);

            // ACT
            var result = await _controller.AddRating(model);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRating = Assert.IsType<Rating>(okResult.Value);
            Assert.Equal(model.OrderNumber, returnedRating.OrderNumber);
        }

        [Fact]
        public async Task AddRating_InvalidModel_ReturnsBadRequest()
        {
            // ARRANGE
            _controller.ModelState.AddModelError("MoodysRating", "Required");
            var model = new AddRatingViewModel();

            // ACT
            var result = await _controller.AddRating(model);

            // ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetRating_ExistingId_ReturnsOk()
        {
            // ARRANGE
            var rating = new GetRatingViewModel { Id = 1, MoodysRating = "A" };
            _mockService.Setup(s => s.GetRatingByIdAsync(1)).ReturnsAsync(rating);

            // ACT
            var result = await _controller.GetRating(1);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRating = Assert.IsType<GetRatingViewModel>(okResult.Value);
            Assert.Equal(rating.Id, returnedRating.Id);
        }

        [Fact]
        public async Task GetAllRatings_ReturnsOk()
        {
            // ARRANGE
            var list = new List<GetRatingViewModel> { new GetRatingViewModel { Id = 1 }, new GetRatingViewModel { Id = 2 } };
            _mockService.Setup(s => s.GetAllRatings()).ReturnsAsync(list);

            // ACT
            var result = await _controller.GetAllRatings();

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedList = Assert.IsType<List<GetRatingViewModel>>(okResult.Value);
            Assert.Equal(2, returnedList.Count);
        }

        [Fact]
        public async Task UpdateRating_ValidModel_ReturnsOk()
        {
            // ARRANGE
            var model = new UpdateRatingViewModel { Id = 1, MoodysRating = "AA" };
            var updatedRating = new GetRatingViewModel { Id = 1, MoodysRating = "AA" };
            _mockService.Setup(s => s.UpdateRating(model)).ReturnsAsync(updatedRating);

            // ACT
            var result = await _controller.UpdateRating(1, model);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRating = Assert.IsType<GetRatingViewModel>(okResult.Value);
            Assert.Equal(updatedRating.Id, returnedRating.Id);
        }

        [Fact]
        public async Task UpdateRating_MismatchedId_ReturnsBadRequest()
        {
            // ARRANGE
            var model = new UpdateRatingViewModel { Id = 2 };

            // ACT
            var result = await _controller.UpdateRating(1, model);

            // ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteRating_ValidId_ReturnsOk()
        {
            // ARRANGE
            _mockService.Setup(s => s.RemoveRating(1)).Returns(Task.CompletedTask);

            // ACT
            var result = await _controller.DeleteRating(1);

            // ASSERT
            Assert.IsType<OkResult>(result);
        }
    }
}
