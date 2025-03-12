using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using P7CreateRestApi.Services;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.ViewsModels.Bids;
using Dot.Net.WebApi.Domain;
using System;
using P7CreateRestApi.ViewsModels;

namespace P7CreateRestApiUnitTests.ServiceUnitTests
{
    public class BidServiceUnitTests
    {
        private readonly Mock<IBidRepository> _bidRepositoryMock;
        private readonly BidService _bidService;

        public BidServiceUnitTests()
        {
            _bidRepositoryMock = new Mock<IBidRepository>();
            _bidService = new BidService(_bidRepositoryMock.Object);
        }

        [Fact]
        public async Task AddBid_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var bid = new Bid { BidId = 1, Account = "TestAccount", BidQuantity = 10, BidType = "Type1" };

            // Act
            await _bidService.AddBid(bid);

            // Assert
            _bidRepositoryMock.Verify(repo => repo.AddAsync(bid), Times.Once);
        }

        [Fact]
        public async Task GetAllBids_ShouldReturnMappedViewModels()
        {
            // Arrange
            var bids = new List<Bid>
            {
                new Bid { BidId = 1, Account = "Account1", BidQuantity = 10, BidType = "TypeA" },
                new Bid { BidId = 2, Account = "Account2", BidQuantity = 20, BidType = "TypeB" }
            };

            _bidRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(bids);

            // Act
            var result = await _bidService.GetAllBids();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Account1", result[0].Account);
            Assert.Equal(10, result[0].BidQuantity);
            Assert.Equal("TypeA", result[0].BidType);
        }

        [Fact]
        public async Task GetBidByIdAsync_ShouldReturnBid_WhenBidExists()
        {
            // Arrange
            var bid = new Bid { BidId = 1, Account = "Account1", BidQuantity = 10, BidType = "TypeA" };
            _bidRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(bid);

            // Act
            var result = await _bidService.GetBidByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.BidId);
            Assert.Equal("Account1", result.Account);
        }

        [Fact]
        public async Task GetBidByIdAsync_ShouldThrowKeyNotFoundException_WhenBidDoesNotExist()
        {
            // Arrange
            _bidRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Bid)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bidService.GetBidByIdAsync(1));
            Assert.Equal("L'offre 1 n'existe pas", exception.Message);
        }

        [Fact]
        public async Task RemoveBid_ShouldCallRepositoryDeleteAsync_WhenBidExists()
        {
            // Arrange
            var bid = new Bid { BidId = 1 };
            _bidRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(bid);

            // Act
            await _bidService.RemoveBid(1);

            // Assert
            _bidRepositoryMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task RemoveBid_ShouldThrowKeyNotFoundException_WhenBidDoesNotExist()
        {
            // Arrange
            _bidRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Bid)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bidService.RemoveBid(1));
            Assert.Equal("L'offre 1 n'existe pas", exception.Message);
        }

        [Fact]
        public async Task UpdateBid_ShouldUpdateBidAndReturnViewModel_WhenBidExists()
        {
            // Arrange
            var existingBid = new Bid { BidId = 1, Account = "OldAccount", BidQuantity = 5, BidType = "OldType" };
            var updatedBid = new UpdateBidViewModel { BidId = 1, Account = "NewAccount", BidQuantity = 15, BidType = "NewType" };

            _bidRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingBid);

            // Act
            var result = await _bidService.UpdateBid(updatedBid);

            // Assert
            _bidRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Bid>(b =>
                b.BidId == 1 &&
                b.Account == "NewAccount" &&
                b.BidQuantity == 15 &&
                b.BidType == "NewType")), Times.Once);

            Assert.Equal("NewAccount", result.Account);
            Assert.Equal(15, result.BidQuantity);
            Assert.Equal("NewType", result.BidType);
        }

        [Fact]
        public async Task UpdateBid_ShouldThrowKeyNotFoundException_WhenBidDoesNotExist()
        {
            // Arrange
            var updatedBid = new UpdateBidViewModel { BidId = 1, Account = "NewAccount", BidQuantity = 15, BidType = "NewType" };

            _bidRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Bid)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bidService.UpdateBid(updatedBid));
            Assert.Equal("L'offre 1 n'existe pas", exception.Message);
        }
    }
}
