using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P7CreateRestApi.Migrations
{
    public partial class RatingSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 1,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 1, 31, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3505), new DateTime(2025, 2, 5, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3520), new DateTime(2025, 2, 5, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3521) });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 2,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 2, 2, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3523), new DateTime(2025, 2, 5, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3524), new DateTime(2025, 2, 5, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3524) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 29, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3646), new DateTime(2025, 2, 5, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3647) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 31, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3648), new DateTime(2025, 2, 5, 14, 56, 3, 977, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "FitchRating", "MoodysRating", "OrderNumber", "SandPRating" },
                values: new object[,]
                {
                    { 1, "AAA", "Aaa", (byte)1, "AAA" },
                    { 2, "BBB", "Baa1", (byte)2, "BBB" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 1,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 1, 31, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5207), new DateTime(2025, 2, 5, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5211), new DateTime(2025, 2, 5, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 2,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 2, 2, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5214), new DateTime(2025, 2, 5, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5215), new DateTime(2025, 2, 5, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5215) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 29, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5295), new DateTime(2025, 2, 5, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5295) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 31, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5296), new DateTime(2025, 2, 5, 13, 52, 44, 707, DateTimeKind.Utc).AddTicks(5297) });
        }
    }
}
