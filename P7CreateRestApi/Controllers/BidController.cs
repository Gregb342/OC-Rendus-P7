using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels;
using P7CreateRestApi.ViewsModels.Bids;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBid([FromBody] AddBidViewModel bidViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Bid bid = new Bid
            {
                Account = bidViewModel.Account,
                BidQuantity = bidViewModel.BidQuantity,
                BidType = bidViewModel.BidType,
                Commentary = bidViewModel.Commentary,
            };

            await _bidService.AddBid(bid);
            return Ok(bid);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBid(int id)
        {
            GetBidViewModel existingBid = await _bidService.GetBidByIdAsync(id);

            if (existingBid is null)
            {
                return NotFound($"L'offre {id} n'existe pas.");
            }

            return Ok(existingBid);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllBids()
        {
            List<GetBidViewModel> bidList = await _bidService.GetAllBids();

            if (bidList is null)
            {
                return NotFound("Pas d'offres trouvé dans la base.");
            }

            return Ok(bidList);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBid(int id, [FromBody] UpdateBidViewModel bidViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bidViewModel.BidId)
            {
                return BadRequest("L'ID dans l'URL ne correspond pas à l'ID du corps de la requête.");
            }

            GetBidViewModel updatedBid = await _bidService.UpdateBid(bidViewModel);

            return Ok(updatedBid);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBid(int id)
        {

            await _bidService.RemoveBid(id);

            return Ok();
        }
    }
}