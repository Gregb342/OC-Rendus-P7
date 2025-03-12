using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Repositories.Interfaces;

namespace Dot.Net.WebApi.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(LocalDbContext context) : base(context) { }
    }
}