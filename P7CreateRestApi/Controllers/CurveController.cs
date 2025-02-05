using Dot.Net.WebApi.Domain;
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
            return Ok(cp);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCurvePoint(int id)
        {
            var cp = await _curvePointService.GetCurvePointByIdAsync(id);
            return Ok(cp);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllCurvePoints()
        {
            var list = await _curvePointService.GetAllCurvePoints();
            return Ok(list);
        }

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

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCurvePoint(int id)
        {
            await _curvePointService.RemoveCurvePoint(id);
            return Ok();
        }
    }
}
