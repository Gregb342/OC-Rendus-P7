using P7CreateRestApi.ViewsModels.Rules;

namespace P7CreateRestApi.Services.Interfaces
{
    public interface IRuleService
    {
        Task AddRule(Dot.Net.WebApi.Controllers.Rule rule);
        Task<GetRuleViewModel> GetRuleByIdAsync(int id);
        Task<List<GetRuleViewModel>> GetAllRules();
        Task<GetRuleViewModel> UpdateRule(UpdateRuleViewModel model);
        Task RemoveRule(int id);
    }
}
