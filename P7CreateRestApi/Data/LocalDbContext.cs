using Microsoft.EntityFrameworkCore;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Controllers;
using P7CreateRestApi.Data.Seed;

namespace Dot.Net.WebApi.Data
{
    public class LocalDbContext : DbContext
    {
        public DbSet<User> Users { get; set;}
        public DbSet<Bid> Bids { get; set;}
        public DbSet<CurvePoint> CurvePoints { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Trade> Trades { get; set; }

        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Seed Data
            BidSeed.Seed(builder);
            CurvePointSeed.Seed(builder);
            RatingSeed.Seed(builder);
            RuleSeed.Seed(builder);
            TradeSeed.Seed(builder);
            #endregion
        }

    }
}