﻿// <auto-generated />
using System;
using Dot.Net.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace P7CreateRestApi.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    [Migration("20250207093050_AddIdentityTables")]
    partial class AddIdentityTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dot.Net.WebApi.Controllers.Domain.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FitchRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoodysRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("OrderNumber")
                        .HasColumnType("tinyint");

                    b.Property<string>("SandPRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FitchRating = "AAA",
                            MoodysRating = "Aaa",
                            OrderNumber = (byte)1,
                            SandPRating = "AAA"
                        },
                        new
                        {
                            Id = 2,
                            FitchRating = "BBB",
                            MoodysRating = "Baa1",
                            OrderNumber = (byte)2,
                            SandPRating = "BBB"
                        });
                });

            modelBuilder.Entity("Dot.Net.WebApi.Controllers.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Json")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SqlPart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SqlStr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description de la règle A",
                            Json = "{\"key\":\"valueA\"}",
                            Name = "Règle de Validation A",
                            SqlPart = "WHERE conditionA",
                            SqlStr = "SELECT * FROM TableA",
                            Template = "Template A"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description de la règle B",
                            Json = "{\"key\":\"valueB\"}",
                            Name = "Règle de Validation B",
                            SqlPart = "WHERE conditionB",
                            SqlStr = "SELECT * FROM TableB",
                            Template = "Template B"
                        });
                });

            modelBuilder.Entity("Dot.Net.WebApi.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Dot.Net.WebApi.Domain.Bid", b =>
                {
                    b.Property<int>("BidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidId"), 1L, 1);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("AskPrice")
                        .HasColumnType("float");

                    b.Property<double?>("AskQuantity")
                        .HasColumnType("float");

                    b.Property<string>("Benchmark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BidDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("BidPrice")
                        .HasColumnType("float");

                    b.Property<double?>("BidQuantity")
                        .HasColumnType("float");

                    b.Property<string>("BidSecurity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BidStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BidType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Book")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Commentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DealType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RevisionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevisionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Side")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceListId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trader")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BidId");

                    b.ToTable("Bids");

                    b.HasData(
                        new
                        {
                            BidId = 1,
                            Account = "Account1",
                            AskPrice = 1520.25,
                            AskQuantity = 200.0,
                            Benchmark = "Benchmark1",
                            BidDate = new DateTime(2025, 2, 2, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3541),
                            BidPrice = 1500.75,
                            BidQuantity = 100.5,
                            BidSecurity = "Security1",
                            BidStatus = "Pending",
                            BidType = "Type1",
                            Book = "Book1",
                            Commentary = "Test Commentary 1",
                            CreationDate = new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3546),
                            CreationName = "System",
                            DealName = "Deal1",
                            DealType = "TypeA",
                            RevisionDate = new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3547),
                            RevisionName = "System",
                            Side = "Buy",
                            SourceListId = "Source1",
                            Trader = "Trader1"
                        },
                        new
                        {
                            BidId = 2,
                            Account = "Account2",
                            AskPrice = 1650.5,
                            AskQuantity = 350.0,
                            Benchmark = "Benchmark2",
                            BidDate = new DateTime(2025, 2, 4, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3548),
                            BidPrice = 1600.0,
                            BidQuantity = 300.0,
                            BidSecurity = "Security2",
                            BidStatus = "Completed",
                            BidType = "Type2",
                            Book = "Book2",
                            Commentary = "Test Commentary 2",
                            CreationDate = new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3549),
                            CreationName = "Admin",
                            DealName = "Deal2",
                            DealType = "TypeB",
                            RevisionDate = new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3550),
                            RevisionName = "Admin",
                            Side = "Sell",
                            SourceListId = "Source2",
                            Trader = "Trader2"
                        });
                });

            modelBuilder.Entity("Dot.Net.WebApi.Domain.CurvePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AsOfDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<byte?>("CurveId")
                        .HasColumnType("tinyint");

                    b.Property<double?>("CurvePointValue")
                        .HasColumnType("float");

                    b.Property<double?>("Term")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CurvePoints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AsOfDate = new DateTime(2025, 1, 31, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3638),
                            CreationDate = new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3639),
                            CurveId = (byte)1,
                            CurvePointValue = 100.25,
                            Term = 10.5
                        },
                        new
                        {
                            Id = 2,
                            AsOfDate = new DateTime(2025, 2, 2, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3640),
                            CreationDate = new DateTime(2025, 2, 7, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3640),
                            CurveId = (byte)2,
                            CurvePointValue = 150.5,
                            Term = 15.75
                        });
                });

            modelBuilder.Entity("Dot.Net.WebApi.Domain.Trade", b =>
                {
                    b.Property<int>("TradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TradeId"), 1L, 1);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Benchmark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Book")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("BuyPrice")
                        .HasColumnType("float");

                    b.Property<double?>("BuyQuantity")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DealName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DealType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RevisionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevisionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("SellPrice")
                        .HasColumnType("float");

                    b.Property<double?>("SellQuantity")
                        .HasColumnType("float");

                    b.Property<string>("Side")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceListId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TradeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TradeSecurity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TradeStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TradeId");

                    b.ToTable("Trades");

                    b.HasData(
                        new
                        {
                            TradeId = 1,
                            Account = "TradeAccount1",
                            AccountType = "Type1",
                            Benchmark = "Benchmark1",
                            Book = "Book1",
                            BuyPrice = 1000.0,
                            BuyQuantity = 500.0,
                            CreationDate = new DateTime(2025, 1, 28, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3671),
                            CreationName = "System",
                            DealName = "Deal1",
                            DealType = "TypeA",
                            RevisionDate = new DateTime(2025, 2, 2, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3672),
                            RevisionName = "System",
                            SellPrice = 1050.0,
                            SellQuantity = 250.0,
                            Side = "Buy",
                            SourceListId = "Source1",
                            TradeDate = new DateTime(2025, 1, 28, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3670),
                            TradeSecurity = "Security1",
                            TradeStatus = "Completed",
                            Trader = "Trader1"
                        },
                        new
                        {
                            TradeId = 2,
                            Account = "TradeAccount2",
                            AccountType = "Type2",
                            Benchmark = "Benchmark2",
                            Book = "Book2",
                            BuyPrice = 1100.0,
                            BuyQuantity = 300.0,
                            CreationDate = new DateTime(2025, 1, 30, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3675),
                            CreationName = "Admin",
                            DealName = "Deal2",
                            DealType = "TypeB",
                            RevisionDate = new DateTime(2025, 2, 4, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3675),
                            RevisionName = "Admin",
                            SellPrice = 1150.0,
                            SellQuantity = 150.0,
                            Side = "Sell",
                            SourceListId = "Source2",
                            TradeDate = new DateTime(2025, 1, 30, 9, 30, 50, 574, DateTimeKind.Utc).AddTicks(3674),
                            TradeSecurity = "Security2",
                            TradeStatus = "Pending",
                            Trader = "Trader2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dot.Net.WebApi.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dot.Net.WebApi.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dot.Net.WebApi.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dot.Net.WebApi.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
