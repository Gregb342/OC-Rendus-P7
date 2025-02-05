using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Data;
using P7CreateRestApi.Repositories.Interfaces;

namespace P7CreateRestApi.Repositories
{
    public class RuleRepository : GenericRepository<Rule>, IRuleRepository
    {
        public RuleRepository(LocalDbContext context) : base(context)
        {
        }
    }
}
