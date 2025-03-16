using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Trades;

namespace P7CreateRestApi.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public async Task AddTrade(Trade trade)
        {
            await _tradeRepository.AddAsync(trade);
        }

        public async Task<List<GetTradeViewModel>> GetAllTrades()
        {
            var trades = await _tradeRepository.GetAllAsync();
            return trades.Select(t => new GetTradeViewModel
            {
                TradeId = t.TradeId,
                Account = t.Account,
                AccountType = t.AccountType,
                BuyQuantity = t.BuyQuantity,
                SellQuantity = t.SellQuantity,
                BuyPrice = t.BuyPrice,
                SellPrice = t.SellPrice,
                TradeDate = t.TradeDate,
                TradeSecurity = t.TradeSecurity,
                TradeStatus = t.TradeStatus,
                Trader = t.Trader,
                Benchmark = t.Benchmark,
                Book = t.Book,
                CreationName = t.CreationName,
                CreationDate = t.CreationDate,
                RevisionName = t.RevisionName,
                RevisionDate = t.RevisionDate,
                DealName = t.DealName,
                DealType = t.DealType,
                SourceListId = t.SourceListId,
                Side = t.Side
            }).ToList();
        }

        public async Task<GetTradeViewModel> GetTradeByIdAsync(int tradeId)
        {
            var trade = await _tradeRepository.GetByIdAsync(tradeId)
                        ?? throw new KeyNotFoundException($"Le trade avec l'ID {tradeId} n'existe pas.");
            return new GetTradeViewModel
            {
                TradeId = trade.TradeId,
                Account = trade.Account,
                AccountType = trade.AccountType,
                BuyQuantity = trade.BuyQuantity,
                SellQuantity = trade.SellQuantity,
                BuyPrice = trade.BuyPrice,
                SellPrice = trade.SellPrice,
                TradeDate = trade.TradeDate,
                TradeSecurity = trade.TradeSecurity,
                TradeStatus = trade.TradeStatus,
                Trader = trade.Trader,
                Benchmark = trade.Benchmark,
                Book = trade.Book,
                CreationName = trade.CreationName,
                CreationDate = trade.CreationDate,
                RevisionName = trade.RevisionName,
                RevisionDate = trade.RevisionDate,
                DealName = trade.DealName,
                DealType = trade.DealType,
                SourceListId = trade.SourceListId,
                Side = trade.Side
            };
        }

        public async Task<GetTradeViewModel> UpdateTrade(UpdateTradeViewModel model)
        {
            var trade = await _tradeRepository.GetByIdAsync(model.TradeId)
                        ?? throw new KeyNotFoundException($"Le trade avec l'ID {model.TradeId} n'existe pas.");

            // Mise à jour des propriétés
            trade.Account = model.Account;
            trade.AccountType = model.AccountType;
            trade.BuyQuantity = model.BuyQuantity;
            trade.SellQuantity = model.SellQuantity;
            trade.BuyPrice = model.BuyPrice;
            trade.SellPrice = model.SellPrice;
            trade.TradeDate = model.TradeDate;
            trade.TradeSecurity = model.TradeSecurity;
            trade.TradeStatus = model.TradeStatus;
            trade.Trader = model.Trader;
            trade.Benchmark = model.Benchmark;
            trade.Book = model.Book;
            trade.CreationName = model.CreationName;
            trade.CreationDate = model.CreationDate;
            trade.RevisionName = model.RevisionName;
            trade.RevisionDate = model.RevisionDate;
            trade.DealName = model.DealName;
            trade.DealType = model.DealType;
            trade.SourceListId = model.SourceListId;
            trade.Side = model.Side;

            await _tradeRepository.UpdateAsync(trade);

            return new GetTradeViewModel
            {
                TradeId = trade.TradeId,
                Account = trade.Account,
                AccountType = trade.AccountType,
                BuyQuantity = trade.BuyQuantity,
                SellQuantity = trade.SellQuantity,
                BuyPrice = trade.BuyPrice,
                SellPrice = trade.SellPrice,
                TradeDate = trade.TradeDate,
                TradeSecurity = trade.TradeSecurity,
                TradeStatus = trade.TradeStatus,
                Trader = trade.Trader,
                Benchmark = trade.Benchmark,
                Book = trade.Book,
                CreationName = trade.CreationName,
                CreationDate = trade.CreationDate,
                RevisionName = trade.RevisionName,
                RevisionDate = trade.RevisionDate,
                DealName = trade.DealName,
                DealType = trade.DealType,
                SourceListId = trade.SourceListId,
                Side = trade.Side
            };
        }

        public async Task RemoveTrade(int tradeId)
        {
            var trade = await _tradeRepository.GetByIdAsync(tradeId)
                        ?? throw new KeyNotFoundException($"Le trade avec l'ID {tradeId} n'existe pas.");
            await _tradeRepository.DeleteAsync(trade.TradeId);
        }
    }
}
