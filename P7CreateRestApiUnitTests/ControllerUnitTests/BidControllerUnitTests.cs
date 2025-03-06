using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services.Interfaces;
using Dot.Net.WebApi.Controllers;
using P7CreateRestApi.ViewsModels.Bids;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using P7CreateRestApi.ViewsModels;

namespace P7CreateRestApiUnitTests.ControllerUnitTests
{
    public class BidControllerTests
    {
        private readonly Mock<IBidService> _bidServiceMock;
        private readonly BidController _controller;

        public BidControllerTests()
        {
            _bidServiceMock = new Mock<IBidService>();
            _controller = new BidController(_bidServiceMock.Object);
        }

        [Fact]
        public async Task AddBid_ValidModel_ReturnsOk()
        {
            // Arrange
            var bidViewModel = new AddBidViewModel { Account = "Test", BidQuantity = 100, BidType = "Type", Commentary = "Comment" };

            _bidServiceMock.Setup(s => s.AddBid(It.IsAny<Bid>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddBid(bidViewModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedBid = Assert.IsType<Bid>(okResult.Value);
            Assert.Equal("Test", returnedBid.Account);
        }

        [Fact]
        public async Task AddBid_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Account", "Required");
            var bidViewModel = new AddBidViewModel();

            // Act
            var result = await _controller.AddBid(bidViewModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetBid_ExistingId_ReturnsOk()
        {
            // Arrange
            var bid = new GetBidViewModel { BidId = 1, Account = "Test" };
            _bidServiceMock.Setup(s => s.GetBidByIdAsync(1)).ReturnsAsync(bid);

            // Act
            var result = await _controller.GetBid(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedBid = Assert.IsType<GetBidViewModel>(okResult.Value);
            Assert.Equal(1, returnedBid.BidId);
        }

        [Fact]
        public async Task GetBid_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            _bidServiceMock.Setup(s => s.GetBidByIdAsync(It.IsAny<int>())).ReturnsAsync((GetBidViewModel)null);

            // Act
            var result = await _controller.GetBid(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task GetAllBids_ExistingBids_ReturnsOk()
        {
            // Arrange
            var bids = new List<GetBidViewModel> { new GetBidViewModel { BidId = 1, Account = "Test" } };
            _bidServiceMock.Setup(s => s.GetAllBids()).ReturnsAsync(bids);

            // Act
            var result = await _controller.GetAllBids();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedBids = Assert.IsType<List<GetBidViewModel>>(okResult.Value);
            Assert.Single(returnedBids);
        }

        [Fact]
        public async Task GetAllBids_NoBids_ReturnsNotFound()
        {
            // Arrange
            _bidServiceMock.Setup(s => s.GetAllBids()).ReturnsAsync((List<GetBidViewModel>)null);

            // Act
            var result = await _controller.GetAllBids();

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task UpdateBid_ValidModel_ReturnsOk()
        {
            // Arrange
            var bidViewModel = new UpdateBidViewModel { BidId = 1, Account = "Updated" };
            var updatedBid = new GetBidViewModel { BidId = 1, Account = "Updated" };

            _bidServiceMock.Setup(s => s.UpdateBid(bidViewModel)).ReturnsAsync(updatedBid);

            // Act
            var result = await _controller.UpdateBid(1, bidViewModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedBid = Assert.IsType<GetBidViewModel>(okResult.Value);
            Assert.Equal("Updated", returnedBid.Account);
        }

        [Fact]
        public async Task UpdateBid_MismatchedId_ReturnsBadRequest()
        {
            // Arrange
            var bidViewModel = new UpdateBidViewModel { BidId = 2, Account = "Updated" };

            // Act
            var result = await _controller.UpdateBid(1, bidViewModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteBid_ExistingId_ReturnsOk()
        {
            // Arrange
            _bidServiceMock.Setup(s => s.RemoveBid(It.IsAny<int>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteBid(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
