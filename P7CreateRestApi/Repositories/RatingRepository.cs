using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;
using P7CreateRestApi.Repositories.Interfaces;

namespace P7CreateRestApi.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(LocalDbContext context) : base(context)
        {
        }
    }
}
