using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace P7CreateRestApi.Data.Seed
{
    public class BidSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>().HasData(
                new Bid
                {
                    BidId = 1,
                    Account = "Account1",
                    BidType = "Type1",
                    BidQuantity = 100.5,
                    AskQuantity = 200.0,
                    BidPrice = 1500.75,
                    AskPrice = 1520.25,
                    Benchmark = "Benchmark1",
                    BidDate = DateTime.UtcNow.AddDays(-5),
                    Commentary = "Test Commentary 1",
                    BidSecurity = "Security1",
                    BidStatus = "Pending",
                    Trader = "Trader1",
                    Book = "Book1",
                    CreationName = "System",
                    CreationDate = DateTime.UtcNow,
                    RevisionName = "System",
                    RevisionDate = DateTime.UtcNow,
                    DealName = "Deal1",
                    DealType = "TypeA",
                    SourceListId = "Source1",
                    Side = "Buy"
                },
                new Bid
                {
                    BidId = 2,
                    Account = "Account2",
                    BidType = "Type2",
                    BidQuantity = 300.0,
                    AskQuantity = 350.0,
                    BidPrice = 1600.00,
                    AskPrice = 1650.50,
                    Benchmark = "Benchmark2",
                    BidDate = DateTime.UtcNow.AddDays(-3),
                    Commentary = "Test Commentary 2",
                    BidSecurity = "Security2",
                    BidStatus = "Completed",
                    Trader = "Trader2",
                    Book = "Book2",
                    CreationName = "Admin",
                    CreationDate = DateTime.UtcNow,
                    RevisionName = "Admin",
                    RevisionDate = DateTime.UtcNow,
                    DealName = "Deal2",
                    DealType = "TypeB",
                    SourceListId = "Source2",
                    Side = "Sell"
                }
                );
        }
    }
}
