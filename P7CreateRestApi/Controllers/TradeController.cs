using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Trades;
using Dot.Net.WebApi.Domain;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddTrade([FromBody] AddTradeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Mapper le ViewModel en entité
            Trade trade = new Trade
            {
                Account = model.Account,
                AccountType = model.AccountType,
                BuyQuantity = model.BuyQuantity,
                SellQuantity = model.SellQuantity,
                BuyPrice = model.BuyPrice,
                SellPrice = model.SellPrice,
                TradeDate = model.TradeDate,
                TradeSecurity = model.TradeSecurity,
                TradeStatus = model.TradeStatus,
                Trader = model.Trader,
                Benchmark = model.Benchmark,
                Book = model.Book,
                CreationName = model.CreationName,
                CreationDate = model.CreationDate,
                RevisionName = model.RevisionName,
                RevisionDate = model.RevisionDate,
                DealName = model.DealName,
                DealType = model.DealType,
                SourceListId = model.SourceListId,
                Side = model.Side
            };

            await _tradeService.AddTrade(trade);
            return Ok(trade);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrade(int id)
        {
            var trade = await _tradeService.GetTradeByIdAsync(id);
            return Ok(trade);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllTrades()
        {
            var trades = await _tradeService.GetAllTrades();
            return Ok(trades);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrade(int id, [FromBody] UpdateTradeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.TradeId)
                return BadRequest("L'ID dans l'URL ne correspond pas à l'ID du corps de la requête.");

            var updatedTrade = await _tradeService.UpdateTrade(model);
            return Ok(updatedTrade);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrade(int id)
        {
            await _tradeService.RemoveTrade(id);
            return Ok();
        }
    }
}
