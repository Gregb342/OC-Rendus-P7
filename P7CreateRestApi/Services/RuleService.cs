using Dot.Net.WebApi.Controllers;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Rules;

namespace P7CreateRestApi.Services
{
    public class RuleService : IRuleService
    {
        private readonly IRuleRepository _ruleRepository;

        public RuleService(IRuleRepository ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }

        public async Task AddRule(Rule rule)
        {
            await _ruleRepository.AddAsync(rule);
        }

        public async Task<List<GetRuleViewModel>> GetAllRules()
        {
            var rules = await _ruleRepository.GetAllAsync();
            return rules.Select(r => new GetRuleViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Json = r.Json,
                Template = r.Template,
                SqlStr = r.SqlStr,
                SqlPart = r.SqlPart
            }).ToList();
        }

        public async Task<GetRuleViewModel> GetRuleByIdAsync(int id)
        {
            var rule = await _ruleRepository.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"La règle avec l'ID {id} n'existe pas.");

            return new GetRuleViewModel
            {
                Id = rule.Id,
                Name = rule.Name,
                Description = rule.Description,
                Json = rule.Json,
                Template = rule.Template,
                SqlStr = rule.SqlStr,
                SqlPart = rule.SqlPart
            };
        }

        public async Task<GetRuleViewModel> UpdateRule(UpdateRuleViewModel model)
        {
            var rule = await _ruleRepository.GetByIdAsync(model.Id)
                       ?? throw new KeyNotFoundException($"La règle avec l'ID {model.Id} n'existe pas.");

            // Mise à jour des propriétés
            rule.Name = model.Name;
            rule.Description = model.Description;
            rule.Json = model.Json;
            rule.Template = model.Template;
            rule.SqlStr = model.SqlStr;
            rule.SqlPart = model.SqlPart;

            await _ruleRepository.UpdateAsync(rule);

            return new GetRuleViewModel
            {
                Id = rule.Id,
                Name = rule.Name,
                Description = rule.Description,
                Json = rule.Json,
                Template = rule.Template,
                SqlStr = rule.SqlStr,
                SqlPart = rule.SqlPart
            };
        }

        public async Task RemoveRule(int id)
        {
            var rule = await _ruleRepository.GetByIdAsync(id)
                       ?? throw new KeyNotFoundException($"La règle avec l'ID {id} n'existe pas.");

            await _ruleRepository.DeleteAsync(rule.Id);
        }
    }
}
