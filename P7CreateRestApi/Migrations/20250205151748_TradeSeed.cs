using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P7CreateRestApi.Migrations
{
    public partial class TradeSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 1,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 1, 31, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9509), new DateTime(2025, 2, 5, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9514), new DateTime(2025, 2, 5, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9515) });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 2,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 2, 2, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9516), new DateTime(2025, 2, 5, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9517), new DateTime(2025, 2, 5, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 29, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9613), new DateTime(2025, 2, 5, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9614) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 31, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9615), new DateTime(2025, 2, 5, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9616) });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "TradeId", "Account", "AccountType", "Benchmark", "Book", "BuyPrice", "BuyQuantity", "CreationDate", "CreationName", "DealName", "DealType", "RevisionDate", "RevisionName", "SellPrice", "SellQuantity", "Side", "SourceListId", "TradeDate", "TradeSecurity", "TradeStatus", "Trader" },
                values: new object[,]
                {
                    { 1, "TradeAccount1", "Type1", "Benchmark1", "Book1", 1000.0, 500.0, new DateTime(2025, 1, 26, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9652), "System", "Deal1", "TypeA", new DateTime(2025, 1, 31, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9653), "System", 1050.0, 250.0, "Buy", "Source1", new DateTime(2025, 1, 26, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9651), "Security1", "Completed", "Trader1" },
                    { 2, "TradeAccount2", "Type2", "Benchmark2", "Book2", 1100.0, 300.0, new DateTime(2025, 1, 28, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9657), "Admin", "Deal2", "TypeB", new DateTime(2025, 2, 2, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9657), "Admin", 1150.0, 150.0, "Sell", "Source2", new DateTime(2025, 1, 28, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9656), "Security2", "Pending", "Trader2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 1,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 1, 31, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(509), new DateTime(2025, 2, 5, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(513), new DateTime(2025, 2, 5, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(514) });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 2,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 2, 2, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(517), new DateTime(2025, 2, 5, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(517), new DateTime(2025, 2, 5, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(518) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 29, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(602), new DateTime(2025, 2, 5, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(603) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 31, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(604), new DateTime(2025, 2, 5, 15, 10, 9, 664, DateTimeKind.Utc).AddTicks(604) });
        }
    }
}
