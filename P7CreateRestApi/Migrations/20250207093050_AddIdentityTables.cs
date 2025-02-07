using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P7CreateRestApi.Migrations
{
    public partial class AddIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 1,
                columns: new[] { "CreationDate", "RevisionDate", "TradeDate" },
                values: new object[] { new DateTime(2025, 1, 26, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9652), new DateTime(2025, 1, 31, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9653), new DateTime(2025, 1, 26, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9651) });

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "TradeId",
                keyValue: 2,
                columns: new[] { "CreationDate", "RevisionDate", "TradeDate" },
                values: new object[] { new DateTime(2025, 1, 28, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9657), new DateTime(2025, 2, 2, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9657), new DateTime(2025, 1, 28, 15, 17, 48, 338, DateTimeKind.Utc).AddTicks(9656) });
        }
    }
}
