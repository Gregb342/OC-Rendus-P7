using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Rules;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RuleController : ControllerBase
    {
        private readonly IRuleService _ruleService;

        public RuleController(IRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        /// <summary>
        /// Ajout de Rule
        /// </summary>
        /// <param name="model">AddRuleViewModel</param>
        /// <returns>Le DTO basé sur l'objet enregistré en base.</returns>
        [Authorize]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddRule([FromBody] AddRuleViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Mapper le ViewModel en entité
            Rule rule = new Rule
            {
                Name = model.Name,
                Description = model.Description,
                Json = model.Json,
                Template = model.Template,
                SqlStr = model.SqlStr,
                SqlPart = model.SqlPart
            };

            await _ruleService.AddRule(rule);
            return Ok(model);
        }

        /// <summary>
        /// Obtenir un Rule à partir de son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DTO GetRuleViewModel</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRule(int id)
        {
            GetRuleViewModel rule = await _ruleService.GetRuleByIdAsync(id);
            return Ok(rule);
        }

        /// <summary>
        /// Retourne tout les Rules présents en base
        /// </summary>
        /// <returns>Une liste de GetRuleViewModel</returns>
        [Authorize]
        [HttpGet("All")]
        public async Task<IActionResult> GetAllRules()
        {
            List<GetRuleViewModel> rules = await _ruleService.GetAllRules();
            return Ok(rules);
        }

        /// <summary>
        /// Met à jour un objet Rule via DTO
        /// </summary>
        /// <param name="id">ID du Rule à mettre à jour</param>
        /// <param name="model">DTO UpdateRuleViewModel</param>
        /// <returns>GetRuleViewModel mis à jour</returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRule(int id, [FromBody] UpdateRuleViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return BadRequest("L'ID dans l'URL ne correspond pas à l'ID du corps de la requête.");

            GetRuleViewModel updatedRule = await _ruleService.UpdateRule(model);
            return Ok(updatedRule);
        }

        /// <summary>
        /// Supprime un Rule
        /// </summary>
        /// <param name="id">Id du Rule à supprimer</param>
        /// <returns>Ok</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRule(int id)
        {
            await _ruleService.RemoveRule(id);
            return Ok();
        }
    }
}
