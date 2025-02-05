using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Ratings;
using Dot.Net.WebApi.Controllers.Domain;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddRating([FromBody] AddRatingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Mapper le ViewModel en entité
            Rating rating = new Rating
            {
                MoodysRating = model.MoodysRating,
                SandPRating = model.SandPRating,
                FitchRating = model.FitchRating,
                OrderNumber = model.OrderNumber
            };

            await _ratingService.AddRating(rating);
            return Ok(rating);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRating(int id)
        {
            var rating = await _ratingService.GetRatingByIdAsync(id);
            return Ok(rating);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllRatings();
            return Ok(ratings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] UpdateRatingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return BadRequest("L'ID dans l'URL ne correspond pas à l'ID du corps de la requête.");

            var updatedRating = await _ratingService.UpdateRating(model);
            return Ok(updatedRating);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            await _ratingService.RemoveRating(id);
            return Ok();
        }
    }
}
