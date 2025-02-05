using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P7CreateRestApi.Migrations
{
    public partial class RuleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Rules",
                columns: new[] { "Id", "Description", "Json", "Name", "SqlPart", "SqlStr", "Template" },
                values: new object[,]
                {
                    { 1, "Description de la règle A", "{\"key\":\"valueA\"}", "Règle de Validation A", "WHERE conditionA", "SELECT * FROM TableA", "Template A" },
                    { 2, "Description de la règle B", "{\"key\":\"valueB\"}", "Règle de Validation B", "WHERE conditionB", "SELECT * FROM TableB", "Template B" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 2);

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
        }
    }
}
