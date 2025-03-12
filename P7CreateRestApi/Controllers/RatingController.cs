using Dot.Net.WebApi.Controllers.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Ratings;

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

        /// <summary>
        /// Ajout de Rating
        /// </summary>
        /// <param name="model">AddRatingViewModel</param>
        /// <returns>Le DTO basé sur l'objet enregistré en base.</returns>
        [Authorize]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddRating([FromBody] AddRatingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Rating rating = new Rating
            {
                MoodysRating = model.MoodysRating,
                SandPRating = model.SandPRating,
                FitchRating = model.FitchRating,
                OrderNumber = model.OrderNumber
            };

            await _ratingService.AddRating(rating);
            return Ok(model);
        }

        /// <summary>
        /// Obtenir un rating à partir de son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DTO GetRatingViewModel</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRating(int id)
        {
            GetRatingViewModel rating = await _ratingService.GetRatingByIdAsync(id);
            return Ok(rating);
        }

        /// <summary>
        /// Retourne tout les Rating présents en base
        /// </summary>
        /// <returns>Une liste de GetRatingViewModel</returns>
        [Authorize]
        [HttpGet("All")]
        public async Task<IActionResult> GetAllRatings()
        {
            List<GetRatingViewModel> ratings = await _ratingService.GetAllRatings();
            return Ok(ratings);
        }

        /// <summary>
        /// Met à jour un objet Rating via DTO
        /// </summary>
        /// <param name="id">ID du Rating à mettre à jour</param>
        /// <param name="model">DTO UpdateCurvePointViewModel</param>
        /// <returns>GetRatingViewModel mis à jour</returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] UpdateRatingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return BadRequest("L'ID dans l'URL ne correspond pas à l'ID du corps de la requête.");

            GetRatingViewModel updatedRating = await _ratingService.UpdateRating(model);
            return Ok(updatedRating);
        }

        /// <summary>
        /// Supprime un rating
        /// </summary>
        /// <param name="id">Id du rating à supprimer</param>
        /// <returns>Ok</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            await _ratingService.RemoveRating(id);
            return Ok();
        }
    }
}
