using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Trades;

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

        /// <summary>
        /// Ajout de Trade
        /// </summary>
        /// <param name="model">AddTradeViewModel</param>
        /// <returns>Le DTO basé sur l'objet enregistré en base.</returns>
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
            return Ok(model);
        }

        /// <summary>
        /// Obtenir un Trade à partir de son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DTO GetTradeViewModel</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrade(int id)
        {
            GetTradeViewModel trade = await _tradeService.GetTradeByIdAsync(id);
            return Ok(trade);
        }

        /// <summary>
        /// Retourne tout les Trades présents en base
        /// </summary>
        /// <returns>Une liste de GetTradeViewModel</returns>
        [HttpGet("All")]
        public async Task<IActionResult> GetAllTrades()
        {
            List<GetTradeViewModel> trades = await _tradeService.GetAllTrades();
            return Ok(trades);
        }

        /// <summary>
        /// Met à jour un objet Trade via DTO
        /// </summary>
        /// <param name="id">ID du Trade à mettre à jour</param>
        /// <param name="model">DTO UpdateTradeViewModel</param>
        /// <returns>GetTradeViewModel mis à jour</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrade(int id, [FromBody] UpdateTradeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.TradeId)
                return BadRequest("L'ID dans l'URL ne correspond pas à l'ID du corps de la requête.");

            GetTradeViewModel updatedTrade = await _tradeService.UpdateTrade(model);
            return Ok(updatedTrade);
        }

        /// <summary>
        /// Supprime un Trade
        /// </summary>
        /// <param name="id">Id du Trade à supprimer</param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrade(int id)
        {
            await _tradeService.RemoveTrade(id);
            return Ok();
        }
    }
}
