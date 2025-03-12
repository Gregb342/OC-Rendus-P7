using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Trades;

namespace P7CreateRestApiUnitTests.ControllerUnitTests
{
    public class TradeControllerUnitTests
    {
        private readonly Mock<ITradeService> _mockService;
        private readonly TradeController _controller;

        public TradeControllerUnitTests()
        {
            _mockService = new Mock<ITradeService>();
            _controller = new TradeController(_mockService.Object);
        }

        [Fact]
        public async Task AddTrade_ValidModel_ReturnsOk()
        {
            // ARRANGE
            var model = new AddTradeViewModel { Account = "TestAccount", BuyQuantity = 10 };
            var trade = new Trade { Account = "TestAccount", BuyQuantity = 10 };

            _mockService.Setup(s => s.AddTrade(It.IsAny<Trade>())).Returns(Task.CompletedTask);

            // ACT
            var result = await _controller.AddTrade(model);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTrade = Assert.IsType<Trade>(okResult.Value);
            Assert.Equal(model.Account, returnedTrade.Account);
        }

        [Fact]
        public async Task AddTrade_InvalidModel_ReturnsBadRequest()
        {
            // ARRANGE
            _controller.ModelState.AddModelError("Account", "Required");
            var model = new AddTradeViewModel();

            // ACT
            var result = await _controller.AddTrade(model);

            // ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetTrade_ExistingId_ReturnsOk()
        {
            // ARRANGE
            var trade = new GetTradeViewModel { TradeId = 1, Account = "TestAccount" };
            _mockService.Setup(s => s.GetTradeByIdAsync(1)).ReturnsAsync(trade);

            // ACT
            var result = await _controller.GetTrade(1);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTrade = Assert.IsType<GetTradeViewModel>(okResult.Value);
            Assert.Equal(trade.TradeId, returnedTrade.TradeId);
        }

        [Fact]
        public async Task GetAllTrades_ReturnsOk()
        {
            // ARRANGE
            var list = new List<GetTradeViewModel> { new GetTradeViewModel { TradeId = 1 }, new GetTradeViewModel { TradeId = 2 } };
            _mockService.Setup(s => s.GetAllTrades()).ReturnsAsync(list);

            // ACT
            var result = await _controller.GetAllTrades();

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedList = Assert.IsType<List<GetTradeViewModel>>(okResult.Value);
            Assert.Equal(2, returnedList.Count);
        }

        [Fact]
        public async Task UpdateTrade_ValidModel_ReturnsOk()
        {
            // ARRANGE
            var model = new UpdateTradeViewModel { TradeId = 1, Account = "UpdatedAccount" };
            var updatedTrade = new GetTradeViewModel { TradeId = 1, Account = "UpdatedAccount" };
            _mockService.Setup(s => s.UpdateTrade(model)).ReturnsAsync(updatedTrade);

            // ACT
            var result = await _controller.UpdateTrade(1, model);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTrade = Assert.IsType<GetTradeViewModel>(okResult.Value);
            Assert.Equal(updatedTrade.TradeId, returnedTrade.TradeId);
        }

        [Fact]
        public async Task UpdateTrade_MismatchedId_ReturnsBadRequest()
        {
            // ARRANGE
            var model = new UpdateTradeViewModel { TradeId = 2 };

            // ACT
            var result = await _controller.UpdateTrade(1, model);

            // ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteTrade_ValidId_ReturnsOk()
        {
            // ARRANGE
            _mockService.Setup(s => s.RemoveTrade(1)).Returns(Task.CompletedTask);

            // ACT
            var result = await _controller.DeleteTrade(1);

            // ASSERT
            Assert.IsType<OkResult>(result);
        }
    }
}
