using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P7CreateRestApi.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 1,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 2, 2, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8722), new DateTime(2025, 2, 7, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 2, 7, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 2,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 2, 4, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8734), new DateTime(2025, 2, 7, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8735), new DateTime(2025, 2, 7, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8736) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 31, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8852), new DateTime(2025, 2, 7, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8859) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 2, 2, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8860), new DateTime(2025, 2, 7, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 1,
                columns: new[] { "CreationDate", "RevisionDate", "TradeDate" },
                values: new object[] { new DateTime(2025, 1, 28, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8936), new DateTime(2025, 2, 2, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8936), new DateTime(2025, 1, 28, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8933) });

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 2,
                columns: new[] { "CreationDate", "RevisionDate", "TradeDate" },
                values: new object[] { new DateTime(2025, 1, 30, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8948), new DateTime(2025, 2, 4, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8948), new DateTime(2025, 1, 30, 10, 50, 59, 145, DateTimeKind.Utc).AddTicks(8941) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 1,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 2, 2, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3541), new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3546), new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 2,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 2, 4, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3548), new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3549), new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3550) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 1, 31, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3638), new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3639) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 2, 2, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3640), new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3640) });

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 1,
                columns: new[] { "CreationDate", "RevisionDate", "TradeDate" },
                values: new object[] { new DateTime(2025, 1, 28, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3671), new DateTime(2025, 2, 2, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3672), new DateTime(2025, 1, 28, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 2,
                columns: new[] { "CreationDate", "RevisionDate", "TradeDate" },
                values: new object[] { new DateTime(2025, 1, 30, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3675), new DateTime(2025, 2, 4, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3675), new DateTime(2025, 1, 30, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3674) });
        }
    }
}
