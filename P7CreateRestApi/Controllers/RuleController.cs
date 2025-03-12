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
            return Ok(rule);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRule(int id)
        {
            var rule = await _ruleService.GetRuleByIdAsync(id);
            return Ok(rule);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllRules()
        {
            var rules = await _ruleService.GetAllRules();
            return Ok(rules);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRule(int id, [FromBody] UpdateRuleViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return BadRequest("L'ID dans l'URL ne correspond pas à l'ID du corps de la requête.");

            var updatedRule = await _ruleService.UpdateRule(model);
            return Ok(updatedRule);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRule(int id)
        {
            await _ruleService.RemoveRule(id);
            return Ok();
        }
    }
}
