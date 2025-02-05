using Dot.Net.WebApi.Domain;
using P7CreateRestApi.ViewsModels.Trades;

namespace P7CreateRestApi.Services.Interfaces
{
    public interface ITradeService
    {
        Task AddTrade(Trade trade);
        Task<GetTradeViewModel> GetTradeByIdAsync(int tradeId);
        Task<List<GetTradeViewModel>> GetAllTrades();
        Task<GetTradeViewModel> UpdateTrade(UpdateTradeViewModel model);
        Task RemoveTrade(int tradeId);
    }
}
