using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using P7CreateRestApi.Services;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.ViewsModels.Trades;
using Dot.Net.WebApi.Domain;
using System;

namespace P7CreateRestApiUnitTests.ServiceUnitTests;
public class TradeServiceUnitTests
{
    private readonly Mock<ITradeRepository> _mockTradeRepository;
    private readonly TradeService _tradeService;

    public TradeServiceUnitTests()
    {
        _mockTradeRepository = new Mock<ITradeRepository>();
        _tradeService = new TradeService(_mockTradeRepository.Object);
    }

    [Fact]
    public async Task AddTrade_ShouldCallRepository()
    {
        var trade = new Trade { TradeId = 1, Account = "TestAccount" };

        await _tradeService.AddTrade(trade);

        _mockTradeRepository.Verify(r => r.AddAsync(trade), Times.Once);
    }

    [Fact]
    public async Task GetAllTrades_ShouldReturnTradeList()
    {
        var trades = new List<Trade>
        {
            new Trade { TradeId = 1, Account = "Account1" },
            new Trade { TradeId = 2, Account = "Account2" }
        };
        _mockTradeRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(trades);

        var result = await _tradeService.GetAllTrades();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Account1", result[0].Account);
    }

    [Fact]
    public async Task GetTradeByIdAsync_ShouldReturnTrade_WhenTradeExists()
    {
        var trade = new Trade { TradeId = 1, Account = "Account1" };
        _mockTradeRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(trade);

        var result = await _tradeService.GetTradeByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.TradeId);
        Assert.Equal("Account1", result.Account);
    }

    [Fact]
    public async Task GetTradeByIdAsync_ShouldThrowKeyNotFoundException_WhenTradeDoesNotExist()
    {
        _mockTradeRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Trade)null);

        await Assert.ThrowsAsync<KeyNotFoundException>(() => _tradeService.GetTradeByIdAsync(1));
    }

    [Fact]
    public async Task UpdateTrade_ShouldUpdateTrade_WhenTradeExists()
    {
        var trade = new Trade { TradeId = 1, Account = "OldAccount" };
        var updatedTrade = new UpdateTradeViewModel { TradeId = 1, Account = "NewAccount" };

        _mockTradeRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(trade);

        var result = await _tradeService.UpdateTrade(updatedTrade);

        _mockTradeRepository.Verify(r => r.UpdateAsync(trade), Times.Once);
        Assert.Equal("NewAccount", result.Account);
    }

    [Fact]
    public async Task UpdateTrade_ShouldThrowKeyNotFoundException_WhenTradeDoesNotExist()
    {
        var updatedTrade = new UpdateTradeViewModel { TradeId = 1, Account = "NewAccount" };
        _mockTradeRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Trade)null);

        await Assert.ThrowsAsync<KeyNotFoundException>(() => _tradeService.UpdateTrade(updatedTrade));
    }

    [Fact]
    public async Task RemoveTrade_ShouldCallDelete_WhenTradeExists()
    {
        var trade = new Trade { TradeId = 1 };
        _mockTradeRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(trade);

        await _tradeService.RemoveTrade(1);

        _mockTradeRepository.Verify(r => r.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task RemoveTrade_ShouldThrowKeyNotFoundException_WhenTradeDoesNotExist()
    {
        _mockTradeRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Trade)null);

        await Assert.ThrowsAsync<KeyNotFoundException>(() => _tradeService.RemoveTrade(1));
    }
}
