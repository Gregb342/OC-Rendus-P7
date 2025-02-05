using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Repositories.Interfaces;

namespace P7CreateRestApi.Repositories
{
    public class CurvePointRepository : GenericRepository<CurvePoint>, ICurvePointRepository
    {
        public CurvePointRepository(LocalDbContext context) : base(context) { }
    }
}
