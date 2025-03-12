using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace P7CreateRestApi.Data.Seed
{
    public class TradeSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>().HasData(
                new Trade
                {
                    TradeId = 1,
                    Account = "TradeAccount1",
                    AccountType = "Type1",
                    BuyQuantity = 500.0,
                    SellQuantity = 250.0,
                    BuyPrice = 1000.0,
                    SellPrice = 1050.0,
                    TradeDate = DateTime.UtcNow.AddDays(-10),
                    TradeSecurity = "Security1",
                    TradeStatus = "Completed",
                    Trader = "Trader1",
                    Benchmark = "Benchmark1",
                    Book = "Book1",
                    CreationName = "System",
                    CreationDate = DateTime.UtcNow.AddDays(-10),
                    RevisionName = "System",
                    RevisionDate = DateTime.UtcNow.AddDays(-5),
                    DealName = "Deal1",
                    DealType = "TypeA",
                    SourceListId = "Source1",
                    Side = "Buy"
                },
                new Trade
                {
                    TradeId = 2,
                    Account = "TradeAccount2",
                    AccountType = "Type2",
                    BuyQuantity = 300.0,
                    SellQuantity = 150.0,
                    BuyPrice = 1100.0,
                    SellPrice = 1150.0,
                    TradeDate = DateTime.UtcNow.AddDays(-8),
                    TradeSecurity = "Security2",
                    TradeStatus = "Pending",
                    Trader = "Trader2",
                    Benchmark = "Benchmark2",
                    Book = "Book2",
                    CreationName = "Admin",
                    CreationDate = DateTime.UtcNow.AddDays(-8),
                    RevisionName = "Admin",
                    RevisionDate = DateTime.UtcNow.AddDays(-3),
                    DealName = "Deal2",
                    DealType = "TypeB",
                    SourceListId = "Source2",
                    Side = "Sell"
                }
            );
        }
    }
}
