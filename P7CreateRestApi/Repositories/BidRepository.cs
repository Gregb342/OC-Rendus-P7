using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories.Interfaces;

namespace P7CreateRestApi.Repositories
{
    public class BidRepository : GenericRepository<Bid>, IBidRepository
    {
        public BidRepository(LocalDbContext context) : base(context) { }
    }
}
