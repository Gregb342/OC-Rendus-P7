using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P7CreateRestApi.Migrations
{
    public partial class ChangeApplicationUserFullNameNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 1,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 2, 28, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6679), new DateTime(2025, 3, 5, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6683), new DateTime(2025, 3, 5, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6684) });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 2,
                columns: new[] { "BidDate", "CreationDate", "RevisionDate" },
                values: new object[] { new DateTime(2025, 3, 2, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6686), new DateTime(2025, 3, 5, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6687), new DateTime(2025, 3, 5, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6687) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 2, 26, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6779), new DateTime(2025, 3, 5, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "CurvePoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AsOfDate", "CreationDate" },
                values: new object[] { new DateTime(2025, 2, 28, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6782), new DateTime(2025, 3, 5, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6782) });

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 1,
                columns: new[] { "CreationDate", "RevisionDate", "TradeDate" },
                values: new object[] { new DateTime(2025, 2, 23, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6825), new DateTime(2025, 2, 28, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6826), new DateTime(2025, 2, 23, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6823) });

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 2,
                columns: new[] { "CreationDate", "RevisionDate", "TradeDate" },
                values: new object[] { new DateTime(2025, 2, 25, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6862), new DateTime(2025, 3, 2, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6862), new DateTime(2025, 2, 25, 10, 16, 17, 420, DateTimeKind.Utc).AddTicks(6860) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
