using Dot.Net.WebApi.Controllers.Domain;
using Moq;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services;
using P7CreateRestApi.ViewsModels.Ratings;

namespace P7CreateRestApiUnitTests.ServiceUnitTests
{
    public class RatingServiceUnitTests
    {
        private readonly Mock<IRatingRepository> _ratingRepositoryMock;
        private readonly RatingService _ratingService;

        public RatingServiceUnitTests()
        {
            _ratingRepositoryMock = new Mock<IRatingRepository>();
            _ratingService = new RatingService(_ratingRepositoryMock.Object);
        }

        [Fact]
        public async Task AddRating_Should_Call_Repository_AddAsync()
        {
            // ARRANGE
            var rating = new Rating { Id = 1, MoodysRating = "A", SandPRating = "AA", FitchRating = "AAA", OrderNumber = 1 };

            // ACT
            await _ratingService.AddRating(rating);

            // ASSERT
            _ratingRepositoryMock.Verify(repo => repo.AddAsync(rating), Times.Once);
        }

        [Fact]
        public async Task GetAllRatings_Should_Return_List_Of_GetRatingViewModel()
        {
            // ARRANGE
            var ratings = new List<Rating>
            {
                new Rating { Id = 1, MoodysRating = "A", SandPRating = "AA", FitchRating = "AAA", OrderNumber = 1 },
                new Rating { Id = 2, MoodysRating = "B", SandPRating = "BB", FitchRating = "BBB", OrderNumber = 2 }
            };

            _ratingRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(ratings);

            // ACT
            var result = await _ratingService.GetAllRatings();

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("A", result.First().MoodysRating);
        }

        [Fact]
        public async Task GetRatingByIdAsync_Should_Return_GetRatingViewModel_When_Found()
        {
            // ARRANGE
            var rating = new Rating { Id = 1, MoodysRating = "A", SandPRating = "AA", FitchRating = "AAA", OrderNumber = 1 };
            _ratingRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(rating);

            // ACT
            var result = await _ratingService.GetRatingByIdAsync(1);

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("A", result.MoodysRating);
        }

        [Fact]
        public async Task GetRatingByIdAsync_Should_Throw_Exception_When_Not_Found()
        {
            // ARRANGE
            _ratingRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Rating)null);

            // ACT & ASSERT
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _ratingService.GetRatingByIdAsync(1));
            Assert.Equal("Le rating avec l'ID 1 n'existe pas.", exception.Message);
        }

        [Fact]
        public async Task UpdateRating_Should_Update_Existing_Rating()
        {
            // ARRANGE
            var existingRating = new Rating { Id = 1, MoodysRating = "A", SandPRating = "AA", FitchRating = "AAA", OrderNumber = 1 };
            var updateModel = new UpdateRatingViewModel { Id = 1, MoodysRating = "B", SandPRating = "BB", FitchRating = "BBB", OrderNumber = 2 };

            _ratingRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingRating);

            // ACT
            var result = await _ratingService.UpdateRating(updateModel);

            // ASSERT
            Assert.Equal("B", result.MoodysRating);
            Assert.Equal("BB", result.SandPRating);
            Assert.Equal("BBB", result.FitchRating);
            _ratingRepositoryMock.Verify(repo => repo.UpdateAsync(existingRating), Times.Once);
        }

        [Fact]
        public async Task UpdateRating_Should_Throw_Exception_When_Not_Found()
        {
            // ARRANGE
            var updateModel = new UpdateRatingViewModel { Id = 1, MoodysRating = "B", SandPRating = "BB", FitchRating = "BBB", OrderNumber = 2 };
            _ratingRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Rating)null);

            // ACT & ASSERT
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _ratingService.UpdateRating(updateModel));
            Assert.Equal("Le rating avec l'ID 1 n'existe pas.", exception.Message);
        }

        [Fact]
        public async Task RemoveRating_Should_Call_DeleteAsync_When_Rating_Exists()
        {
            // ARRRANGE
            var rating = new Rating { Id = 1, MoodysRating = "A", SandPRating = "AA", FitchRating = "AAA", OrderNumber = 1 };
            _ratingRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(rating);

            // ACT
            await _ratingService.RemoveRating(1);

            // ASSERT
            _ratingRepositoryMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task RemoveRating_Should_Throw_Exception_When_Not_Found()
        {
            // ARRANGE
            _ratingRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Rating)null);

            // ACT & ASSERT
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _ratingService.RemoveRating(1));
            Assert.Equal("Le rating avec l'ID 1 n'existe pas.", exception.Message);
        }
    }
}
