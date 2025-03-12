using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.CurvePoints;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurvePointController : ControllerBase
    {
        private readonly ICurvePointService _curvePointService;

        public CurvePointController(ICurvePointService curvePointService)
        {
            _curvePointService = curvePointService;
        }

        /// <summary>
        /// Ajout de CurvePoint
        /// </summary>
        /// <param name="model">AddCurvePointViewModel</param>
        /// <returns>Le DTO basé sur l'objet enregistré en base.</returns>
        [Authorize]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCurvePoint([FromBody] AddCurvePointViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CurvePoint cp = new CurvePoint
            {
                CurveId = model.CurveId,
                AsOfDate = model.AsOfDate,
                Term = model.Term,
                CurvePointValue = model.CurvePointValue,
                CreationDate = DateTime.UtcNow
            };

            await _curvePointService.AddCurvePoint(cp);
            return Ok(model);
        }

        /// <summary>
        /// Obtenir un curvepoint à partir de son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DTO GetCurvePointViewModel</returns>
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCurvePoint(int id)
        {
            GetCurvePointViewModel cp = await _curvePointService.GetCurvePointByIdAsync(id);
            return Ok(cp);
        }

        /// <summary>
        /// Retourne tout les CurvePoint présents en base
        /// </summary>
        /// <returns>Une liste de GetCurvePointViewModel</returns>
        [Authorize]
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllCurvePoints()
        {
            List<GetCurvePointViewModel> list = await _curvePointService.GetAllCurvePoints();
            return Ok(list);
        }

        /// <summary>
        /// Met à jour un objet CurvePoint via DTO
        /// </summary>
        /// <param name="id">ID du Curvepoint à mettre à jour</param>
        /// <param name="model">DTO UpdateCurvePointViewModel</param>
        /// <returns>GetCurvePointViewModel mis à jour</returns>
        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCurvePoint(int id, [FromBody] UpdateCurvePointViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return BadRequest("L'ID dans l'URL ne correspond pas à l'ID du corps de la requête.");

            var updatedCp = await _curvePointService.UpdateCurvePoint(model);
            return Ok(updatedCp);
        }

        /// <summary>
        /// Supprime un curvepoint
        /// </summary>
        /// <param name="id">Id du curvepoint à supprimer</param>
        /// <returns>Ok</returns>
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCurvePoint(int id)
        {
            await _curvePointService.RemoveCurvePoint(id);
            return Ok();
        }
    }
}
