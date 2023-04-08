using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirLineCompanies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLineCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirPlaneTypes",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirPlaneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusTravelCompanies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTravelCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatArrangement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxNumberPassenger = table.Column<int>(type: "int", nullable: false),
                    AllowableAmountLoad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyServiceProviders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyServiceProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightCompanies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupFlightTicketRefundRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFlightTicketRefundRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainTicketRefundRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainTicketRefundRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BithDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefrenceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefrenceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompartmentType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CompartmentCount = table.Column<int>(type: "int", nullable: false),
                    HaveBed = table.Column<bool>(type: "bit", nullable: false),
                    Default_PricePerPersonForClosedCompartment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Default_PricePerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoupeFacilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralTrainFacilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainTicketRefundRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeductibleAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPercent = table.Column<bool>(type: "bit", nullable: false),
                    Start_AfterIssuanceTicket = table.Column<TimeSpan>(type: "time", nullable: true),
                    End_AfterIssuanceTicket = table.Column<TimeSpan>(type: "time", nullable: true),
                    Start_BeforeFlight = table.Column<TimeSpan>(type: "time", nullable: true),
                    End_BeforeFlight = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartHour = table.Column<short>(type: "smallint", nullable: true),
                    EndHour = table.Column<short>(type: "smallint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainTicketRefundRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeServiceProviderAirPlanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeServiceProviderAirPlanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeServiceProviderBuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeServiceProviderBuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeServiceProviderTrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeServiceProviderTrains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirLineContants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirLineId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLineContants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirLineContants_AirLines_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "AirLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirPlanes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<short>(type: "smallint", nullable: false),
                    MaxNumberPassenger = table.Column<int>(type: "int", nullable: false),
                    AllowableAmountLoad = table.Column<int>(type: "int", nullable: false),
                    AirPlaneTypeId = table.Column<short>(type: "smallint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirPlanes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirPlanes_AirPlaneTypes_AirPlaneTypeId",
                        column: x => x.AirPlaneTypeId,
                        principalTable: "AirPlaneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPlates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buses_BusTypes_BusTypeId",
                        column: x => x.BusTypeId,
                        principalTable: "BusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Countries_CountryId1",
                        column: x => x.CountryId1,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightTicketRefundRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeductibleAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPercent = table.Column<bool>(type: "bit", nullable: false),
                    Start_AfterIssuanceTicket = table.Column<TimeSpan>(type: "time", nullable: true),
                    End_AfterIssuanceTicket = table.Column<TimeSpan>(type: "time", nullable: true),
                    Start_BeforeFlight = table.Column<TimeSpan>(type: "time", nullable: true),
                    End_BeforeFlight = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartHour = table.Column<short>(type: "smallint", nullable: true),
                    EndHour = table.Column<short>(type: "smallint", nullable: true),
                    GroupFlightTicketRefundRulesId = table.Column<long>(type: "bigint", nullable: true),
                    GroupTrainTicketRefundRulesId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightTicketRefundRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightTicketRefundRules_GroupFlightTicketRefundRules_GroupFlightTicketRefundRulesId",
                        column: x => x.GroupFlightTicketRefundRulesId,
                        principalTable: "GroupFlightTicketRefundRules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightTicketRefundRules_GroupTrainTicketRefundRules_GroupTrainTicketRefundRulesId",
                        column: x => x.GroupTrainTicketRefundRulesId,
                        principalTable: "GroupTrainTicketRefundRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    En_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    En_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDatePassport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryBirthId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrecent = table.Column<bool>(type: "bit", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxUse = table.Column<int>(type: "int", nullable: true),
                    MaxDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefrenceTypeID = table.Column<int>(type: "int", nullable: true),
                    RefrenceId = table.Column<long>(type: "bigint", nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Important = table.Column<int>(type: "int", nullable: false),
                    IsDoubleDiscount = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_RefrenceTypes_RefrenceTypeID",
                        column: x => x.RefrenceTypeID,
                        principalTable: "RefrenceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainTravels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<long>(type: "bigint", nullable: false),
                    PricePerPersonForClosedCompartment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RefundRulesId = table.Column<long>(type: "bigint", nullable: false),
                    CoupeFacilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralTrainFacilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainTravels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainTravels_GroupTrainTicketRefundRules_RefundRulesId",
                        column: x => x.RefundRulesId,
                        principalTable: "GroupTrainTicketRefundRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainTravels_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    WalletId = table.Column<long>(type: "bigint", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    WalletId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackingCodeBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefrenceID = table.Column<long>(type: "bigint", nullable: false),
                    RefrenceTypeID = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_RefrenceTypes_RefrenceTypeID",
                        column: x => x.RefrenceTypeID,
                        principalTable: "RefrenceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirPlaneId = table.Column<long>(type: "bigint", nullable: true),
                    BusId = table.Column<int>(type: "int", nullable: true),
                    TrainId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AirPlanes_AirPlaneId",
                        column: x => x.AirPlaneId,
                        principalTable: "AirPlanes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AirLineFinancials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirLineId = table.Column<int>(type: "int", nullable: false),
                    EnConomicCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankId = table.Column<long>(type: "bigint", nullable: false),
                    ShabaNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesReportLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLineFinancials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirLineFinancials_AirLines_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "AirLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirLineFinancials_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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
                    UserId = table.Column<long>(type: "bigint", nullable: false)
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CartNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartNumbers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartNumbers_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderAirPlanes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    TypeServiceId = table.Column<long>(type: "bigint", nullable: false),
                    TypeServiceId1 = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderAirPlanes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderAirPlanes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceProviderAirPlanes_CompanyServiceProviders_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "CompanyServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderAirPlanes_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderAirPlanes_TypeServiceProviderAirPlanes_TypeServiceId1",
                        column: x => x.TypeServiceId1,
                        principalTable: "TypeServiceProviderAirPlanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderBuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    TypeServiceId = table.Column<long>(type: "bigint", nullable: false),
                    TypeServiceId1 = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderBuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderBuses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceProviderBuses_CompanyServiceProviders_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "CompanyServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderBuses_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderBuses_TypeServiceProviderBuses_TypeServiceId1",
                        column: x => x.TypeServiceId1,
                        principalTable: "TypeServiceProviderBuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderTrains",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    TypeServiceId = table.Column<long>(type: "bigint", nullable: false),
                    TypeServiceId1 = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderTrains_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceProviderTrains_CompanyServiceProviders_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "CompanyServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderTrains_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderTrains_TypeServiceProviderTrains_TypeServiceId1",
                        column: x => x.TypeServiceId1,
                        principalTable: "TypeServiceProviderTrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketBusReturneds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonForReturned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketBusReturneds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketBusReturneds_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketDomesticFlightReturneds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonForReturned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDomesticFlightReturneds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketDomesticFlightReturneds_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketInternationalFlightReturneds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonForReturned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketInternationalFlightReturneds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketInternationalFlightReturneds_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTrainReturneds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonForReturned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTrainReturneds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTrainReturneds_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsedDiscounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_UsedDiscounts_Transactions_NoCacade = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    GetDiscountCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RefrenceTypeID = table.Column<int>(type: "int", nullable: false),
                    RefrenceId = table.Column<long>(type: "bigint", nullable: false),
                    DiscountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsedDiscounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsedDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsedDiscounts_RefrenceTypes_RefrenceTypeID",
                        column: x => x.RefrenceTypeID,
                        principalTable: "RefrenceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsedDiscounts_Transactions_FK_UsedDiscounts_Transactions_NoCacade",
                        column: x => x.FK_UsedDiscounts_Transactions_NoCacade,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AirplaneTerminals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneTerminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirplaneTerminals_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusTerminals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTerminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusTerminals_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainStations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainStations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderTrainTrainTravel",
                columns: table => new
                {
                    BusTravelsId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceProvidersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderTrainTrainTravel", x => new { x.BusTravelsId, x.ServiceProvidersId });
                    table.ForeignKey(
                        name: "FK_ServiceProviderTrainTrainTravel_ServiceProviderTrains_ServiceProvidersId",
                        column: x => x.ServiceProvidersId,
                        principalTable: "ServiceProviderTrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderTrainTrainTravel_TrainTravels_BusTravelsId",
                        column: x => x.BusTravelsId,
                        principalTable: "TrainTravels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginTerminalId = table.Column<long>(type: "bigint", nullable: false),
                    FK_Flights_AirplaneTerminals_OriginTerminalId = table.Column<long>(type: "bigint", nullable: false),
                    DestinationTerminalId = table.Column<long>(type: "bigint", nullable: false),
                    FK_Flights_AirplaneTerminals_DestinationTerminalId = table.Column<long>(type: "bigint", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxNumberPassenger = table.Column<int>(type: "int", nullable: false),
                    AllowableAmountLoad = table.Column<int>(type: "int", nullable: false),
                    AirPlaneId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    AirLineId = table.Column<long>(type: "bigint", nullable: false),
                    AirLineId1 = table.Column<int>(type: "int", nullable: false),
                    StartMoving = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCharter = table.Column<bool>(type: "bit", nullable: false),
                    TicketRefundRulesId = table.Column<long>(type: "bigint", nullable: false),
                    DiscountId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_AirLines_AirLineId1",
                        column: x => x.AirLineId1,
                        principalTable: "AirLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_AirPlanes_AirPlaneId",
                        column: x => x.AirPlaneId,
                        principalTable: "AirPlanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_AirplaneTerminals_FK_Flights_AirplaneTerminals_DestinationTerminalId",
                        column: x => x.FK_Flights_AirplaneTerminals_DestinationTerminalId,
                        principalTable: "AirplaneTerminals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_AirplaneTerminals_FK_Flights_AirplaneTerminals_OriginTerminalId",
                        column: x => x.FK_Flights_AirplaneTerminals_OriginTerminalId,
                        principalTable: "AirplaneTerminals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_FlightCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "FlightCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_GroupFlightTicketRefundRules_TicketRefundRulesId",
                        column: x => x.TicketRefundRulesId,
                        principalTable: "GroupFlightTicketRefundRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusTravels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginTerminalId = table.Column<long>(type: "bigint", nullable: false),
                    FK_BusTravels_BusTerminals_OriginTerminalId = table.Column<long>(type: "bigint", nullable: false),
                    DestinationTerminalId = table.Column<long>(type: "bigint", nullable: false),
                    FK_BusTravels_BusTerminals_DestinationTerminalId = table.Column<long>(type: "bigint", nullable: false),
                    StartMoving = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllowableAmountLoad = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTravels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusTravels_BusTerminals_FK_BusTravels_BusTerminals_DestinationTerminalId",
                        column: x => x.FK_BusTravels_BusTerminals_DestinationTerminalId,
                        principalTable: "BusTerminals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusTravels_BusTerminals_FK_BusTravels_BusTerminals_OriginTerminalId",
                        column: x => x.FK_BusTravels_BusTerminals_OriginTerminalId,
                        principalTable: "BusTerminals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusTravels_BusTravelCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BusTravelCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusTravels_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTrainReservations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TrainTravelId = table.Column<long>(type: "bigint", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendOtherInformationToPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendOtherInformationToEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_TicketTrainReservations_TrainStations_TrainStationOriginId = table.Column<long>(type: "bigint", nullable: false),
                    FK_TicketTrainReservations_TrainStations_TrainStationDestinationId = table.Column<long>(type: "bigint", nullable: false),
                    IsClosedCompartment = table.Column<bool>(type: "bit", nullable: false),
                    FK_TicketTrainReservations_Transactions_TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTrainReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTrainReservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTrainReservations_TrainStations_FK_TicketTrainReservations_TrainStations_TrainStationDestinationId",
                        column: x => x.FK_TicketTrainReservations_TrainStations_TrainStationDestinationId,
                        principalTable: "TrainStations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketTrainReservations_TrainStations_FK_TicketTrainReservations_TrainStations_TrainStationOriginId",
                        column: x => x.FK_TicketTrainReservations_TrainStations_TrainStationOriginId,
                        principalTable: "TrainStations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketTrainReservations_TrainTravels_TrainTravelId",
                        column: x => x.TrainTravelId,
                        principalTable: "TrainTravels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTrainReservations_Transactions_FK_TicketTrainReservations_Transactions_TransactionId",
                        column: x => x.FK_TicketTrainReservations_Transactions_TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainStationConnects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_TrainStationConnects_TrainStations_TrainStationOriginId = table.Column<long>(type: "bigint", nullable: false),
                    TrainStationOriginIdId = table.Column<long>(type: "bigint", nullable: false),
                    FK_TrainStationConnects_TrainStations_TrainStationDestinationId = table.Column<long>(type: "bigint", nullable: false),
                    TrainStationDestinationId = table.Column<long>(type: "bigint", nullable: false),
                    SpaceBetween = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainStationConnects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainStationConnects_Cities_FK_TrainStationConnects_TrainStations_TrainStationOriginId",
                        column: x => x.FK_TrainStationConnects_TrainStations_TrainStationOriginId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainStationConnects_TrainStations_FK_TrainStationConnects_TrainStations_TrainStationDestinationId",
                        column: x => x.FK_TrainStationConnects_TrainStations_TrainStationDestinationId,
                        principalTable: "TrainStations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainStationConnects_TrainStations_TrainStationOriginIdId",
                        column: x => x.TrainStationOriginIdId,
                        principalTable: "TrainStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomesticFlights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomesticFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomesticFlights_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightServiceProviderAirPlane",
                columns: table => new
                {
                    FlightsId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceProvidersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightServiceProviderAirPlane", x => new { x.FlightsId, x.ServiceProvidersId });
                    table.ForeignKey(
                        name: "FK_FlightServiceProviderAirPlane_Flights_FlightsId",
                        column: x => x.FlightsId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightServiceProviderAirPlane_ServiceProviderAirPlanes_ServiceProvidersId",
                        column: x => x.ServiceProvidersId,
                        principalTable: "ServiceProviderAirPlanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightTags_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InternationalFlights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternationalFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternationalFlights_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusTravelServiceProviderBus",
                columns: table => new
                {
                    BusTravelsId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceProvidersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTravelServiceProviderBus", x => new { x.BusTravelsId, x.ServiceProvidersId });
                    table.ForeignKey(
                        name: "FK_BusTravelServiceProviderBus_BusTravels_BusTravelsId",
                        column: x => x.BusTravelsId,
                        principalTable: "BusTravels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusTravelServiceProviderBus_ServiceProviderBuses_ServiceProvidersId",
                        column: x => x.ServiceProvidersId,
                        principalTable: "ServiceProviderBuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketBusReservations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BusTravelId = table.Column<long>(type: "bigint", nullable: false),
                    FK_TicketBusReservations_Passengers_SupervisorId = table.Column<long>(type: "bigint", nullable: false),
                    SupervisorId = table.Column<long>(type: "bigint", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendOtherInformationToPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendOtherInformationToEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_TicketBusReservations_Transactions_TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketBusReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketBusReservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketBusReservations_BusTravels_BusTravelId",
                        column: x => x.BusTravelId,
                        principalTable: "BusTravels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketBusReservations_Passengers_FK_TicketBusReservations_Passengers_SupervisorId",
                        column: x => x.FK_TicketBusReservations_Passengers_SupervisorId,
                        principalTable: "Passengers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketBusReservations_Transactions_FK_TicketBusReservations_Transactions_TransactionId",
                        column: x => x.FK_TicketBusReservations_Transactions_TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Compartments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TicketTrainId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compartments_TicketTrainReservations_TicketTrainId",
                        column: x => x.TicketTrainId,
                        principalTable: "TicketTrainReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteTrainStationConnects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainStationId = table.Column<long>(type: "bigint", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StopThisDestination = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    TrainId = table.Column<long>(type: "bigint", nullable: false),
                    TrainTravelId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteTrainStationConnects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteTrainStationConnects_TrainStationConnects_TrainStationId",
                        column: x => x.TrainStationId,
                        principalTable: "TrainStationConnects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteTrainStationConnects_TrainTravels_TrainTravelId",
                        column: x => x.TrainTravelId,
                        principalTable: "TrainTravels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RouteTrainStationConnects_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketDomesticFlightReservations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendOtherInformationToPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendOtherInformationToEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_TicketDomesticFlightReservation_Transactions_TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDomesticFlightReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketDomesticFlightReservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketDomesticFlightReservations_DomesticFlights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "DomesticFlights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketDomesticFlightReservations_Transactions_FK_TicketDomesticFlightReservation_Transactions_TransactionId",
                        column: x => x.FK_TicketDomesticFlightReservation_Transactions_TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketInternationalFlightReservations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendOtherInformationToPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendOtherInformationToEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_TicketInternationalFlightReservation_Transactions_TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketInternationalFlightReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketInternationalFlightReservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketInternationalFlightReservations_InternationalFlights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "InternationalFlights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketInternationalFlightReservations_Transactions_FK_TicketInternationalFlightReservation_Transactions_TransactionId",
                        column: x => x.FK_TicketInternationalFlightReservation_Transactions_TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketBuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<long>(type: "bigint", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<long>(type: "bigint", nullable: true),
                    ReturnedId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketBuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketBuses_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketBuses_TicketBusReservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "TicketBusReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketBuses_TicketBusReturneds_ReturnedId",
                        column: x => x.ReturnedId,
                        principalTable: "TicketBusReturneds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeatOrBeds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CompartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatOrBeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatOrBeds_Compartments_CompartmentId",
                        column: x => x.CompartmentId,
                        principalTable: "Compartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketDomesticFlights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerId = table.Column<long>(type: "bigint", nullable: false),
                    FK_TicketDomesticFlights_TicketDomesticFlightReservations_ReservationId = table.Column<long>(type: "bigint", nullable: false),
                    ReturnedId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDomesticFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketDomesticFlights_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketDomesticFlights_TicketDomesticFlightReservations_FK_TicketDomesticFlights_TicketDomesticFlightReservations_Reservation~",
                        column: x => x.FK_TicketDomesticFlights_TicketDomesticFlightReservations_ReservationId,
                        principalTable: "TicketDomesticFlightReservations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketDomesticFlights_TicketDomesticFlightReturneds_ReturnedId",
                        column: x => x.ReturnedId,
                        principalTable: "TicketDomesticFlightReturneds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketInternationalFlights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerId = table.Column<long>(type: "bigint", nullable: false),
                    FK_TicketInternationalFlights_TicketInternationalFlightReservations_ReservationId = table.Column<long>(type: "bigint", nullable: false),
                    ReturnedId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketInternationalFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketInternationalFlights_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketInternationalFlights_TicketInternationalFlightReservations_FK_TicketInternationalFlights_TicketInternationalFlightRese~",
                        column: x => x.FK_TicketInternationalFlights_TicketInternationalFlightReservations_ReservationId,
                        principalTable: "TicketInternationalFlightReservations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketInternationalFlights_TicketInternationalFlightReturneds_ReturnedId",
                        column: x => x.ReturnedId,
                        principalTable: "TicketInternationalFlightReturneds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketTrains",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerId = table.Column<long>(type: "bigint", nullable: false),
                    FK_TicketTrains_SeatOrBeds_SeatOrBedId = table.Column<long>(type: "bigint", nullable: false),
                    ReturnedId = table.Column<long>(type: "bigint", nullable: true),
                    TicketTrainReservationId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTrains_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTrains_SeatOrBeds_FK_TicketTrains_SeatOrBeds_SeatOrBedId",
                        column: x => x.FK_TicketTrains_SeatOrBeds_SeatOrBedId,
                        principalTable: "SeatOrBeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketTrains_TicketTrainReservations_TicketTrainReservationId",
                        column: x => x.TicketTrainReservationId,
                        principalTable: "TicketTrainReservations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketTrains_TicketTrainReturneds_ReturnedId",
                        column: x => x.ReturnedId,
                        principalTable: "TicketTrainReturneds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirLineContants_AirLineId",
                table: "AirLineContants",
                column: "AirLineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AirLineFinancials_AirLineId",
                table: "AirLineFinancials",
                column: "AirLineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AirLineFinancials_BankId",
                table: "AirLineFinancials",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_AirPlanes_AirPlaneTypeId",
                table: "AirPlanes",
                column: "AirPlaneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AirplaneTerminals_CityId",
                table: "AirplaneTerminals",
                column: "CityId");

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
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WalletId",
                table: "AspNetUsers",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_CountryId1",
                table: "Banks",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusTypeId",
                table: "Buses",
                column: "BusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTerminals_CityId",
                table: "BusTerminals",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTravels_BusId",
                table: "BusTravels",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTravels_CompanyId",
                table: "BusTravels",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTravels_FK_BusTravels_BusTerminals_DestinationTerminalId",
                table: "BusTravels",
                column: "FK_BusTravels_BusTerminals_DestinationTerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTravels_FK_BusTravels_BusTerminals_OriginTerminalId",
                table: "BusTravels",
                column: "FK_BusTravels_BusTerminals_OriginTerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTravelServiceProviderBus_ServiceProvidersId",
                table: "BusTravelServiceProviderBus",
                column: "ServiceProvidersId");

            migrationBuilder.CreateIndex(
                name: "IX_CartNumbers_BankId",
                table: "CartNumbers",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CartNumbers_UserId",
                table: "CartNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Compartments_TicketTrainId",
                table: "Compartments",
                column: "TicketTrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_RefrenceTypeID",
                table: "Discounts",
                column: "RefrenceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DomesticFlights_FlightId",
                table: "DomesticFlights",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirLineId1",
                table: "Flights",
                column: "AirLineId1");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirPlaneId",
                table: "Flights",
                column: "AirPlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CompanyId",
                table: "Flights",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DiscountId",
                table: "Flights",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FK_Flights_AirplaneTerminals_DestinationTerminalId",
                table: "Flights",
                column: "FK_Flights_AirplaneTerminals_DestinationTerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FK_Flights_AirplaneTerminals_OriginTerminalId",
                table: "Flights",
                column: "FK_Flights_AirplaneTerminals_OriginTerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TicketRefundRulesId",
                table: "Flights",
                column: "TicketRefundRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightServiceProviderAirPlane_ServiceProvidersId",
                table: "FlightServiceProviderAirPlane",
                column: "ServiceProvidersId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTags_FlightId",
                table: "FlightTags",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTicketRefundRules_GroupFlightTicketRefundRulesId",
                table: "FlightTicketRefundRules",
                column: "GroupFlightTicketRefundRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTicketRefundRules_GroupTrainTicketRefundRulesId",
                table: "FlightTicketRefundRules",
                column: "GroupTrainTicketRefundRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AirPlaneId",
                table: "Images",
                column: "AirPlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_BusId",
                table: "Images",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TrainId",
                table: "Images",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_InternationalFlights_FlightId",
                table: "InternationalFlights",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_PersonId",
                table: "Passengers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteTrainStationConnects_TrainId",
                table: "RouteTrainStationConnects",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteTrainStationConnects_TrainStationId",
                table: "RouteTrainStationConnects",
                column: "TrainStationId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteTrainStationConnects_TrainTravelId",
                table: "RouteTrainStationConnects",
                column: "TrainTravelId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatOrBeds_CompartmentId",
                table: "SeatOrBeds",
                column: "CompartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderAirPlanes_CompanyID",
                table: "ServiceProviderAirPlanes",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderAirPlanes_PersonId",
                table: "ServiceProviderAirPlanes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderAirPlanes_TypeServiceId1",
                table: "ServiceProviderAirPlanes",
                column: "TypeServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderAirPlanes_UserId",
                table: "ServiceProviderAirPlanes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderBuses_CompanyID",
                table: "ServiceProviderBuses",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderBuses_PersonId",
                table: "ServiceProviderBuses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderBuses_TypeServiceId1",
                table: "ServiceProviderBuses",
                column: "TypeServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderBuses_UserId",
                table: "ServiceProviderBuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderTrains_CompanyID",
                table: "ServiceProviderTrains",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderTrains_PersonId",
                table: "ServiceProviderTrains",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderTrains_TypeServiceId1",
                table: "ServiceProviderTrains",
                column: "TypeServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderTrains_UserId",
                table: "ServiceProviderTrains",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderTrainTrainTravel_ServiceProvidersId",
                table: "ServiceProviderTrainTrainTravel",
                column: "ServiceProvidersId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBuses_PassengerId",
                table: "TicketBuses",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBuses_ReservationId",
                table: "TicketBuses",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBuses_ReturnedId",
                table: "TicketBuses",
                column: "ReturnedId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBusReservations_BusTravelId",
                table: "TicketBusReservations",
                column: "BusTravelId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBusReservations_FK_TicketBusReservations_Passengers_SupervisorId",
                table: "TicketBusReservations",
                column: "FK_TicketBusReservations_Passengers_SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBusReservations_FK_TicketBusReservations_Transactions_TransactionId",
                table: "TicketBusReservations",
                column: "FK_TicketBusReservations_Transactions_TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBusReservations_UserId",
                table: "TicketBusReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBusReturneds_TransactionId",
                table: "TicketBusReturneds",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDomesticFlightReservations_FK_TicketDomesticFlightReservation_Transactions_TransactionId",
                table: "TicketDomesticFlightReservations",
                column: "FK_TicketDomesticFlightReservation_Transactions_TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDomesticFlightReservations_FlightId",
                table: "TicketDomesticFlightReservations",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDomesticFlightReservations_UserId",
                table: "TicketDomesticFlightReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDomesticFlightReturneds_TransactionId",
                table: "TicketDomesticFlightReturneds",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDomesticFlights_FK_TicketDomesticFlights_TicketDomesticFlightReservations_ReservationId",
                table: "TicketDomesticFlights",
                column: "FK_TicketDomesticFlights_TicketDomesticFlightReservations_ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDomesticFlights_PassengerId",
                table: "TicketDomesticFlights",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDomesticFlights_ReturnedId",
                table: "TicketDomesticFlights",
                column: "ReturnedId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInternationalFlightReservations_FK_TicketInternationalFlightReservation_Transactions_TransactionId",
                table: "TicketInternationalFlightReservations",
                column: "FK_TicketInternationalFlightReservation_Transactions_TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInternationalFlightReservations_FlightId",
                table: "TicketInternationalFlightReservations",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInternationalFlightReservations_UserId",
                table: "TicketInternationalFlightReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInternationalFlightReturneds_TransactionId",
                table: "TicketInternationalFlightReturneds",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInternationalFlights_FK_TicketInternationalFlights_TicketInternationalFlightReservations_ReservationId",
                table: "TicketInternationalFlights",
                column: "FK_TicketInternationalFlights_TicketInternationalFlightReservations_ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInternationalFlights_PassengerId",
                table: "TicketInternationalFlights",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInternationalFlights_ReturnedId",
                table: "TicketInternationalFlights",
                column: "ReturnedId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrainReservations_FK_TicketTrainReservations_TrainStations_TrainStationDestinationId",
                table: "TicketTrainReservations",
                column: "FK_TicketTrainReservations_TrainStations_TrainStationDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrainReservations_FK_TicketTrainReservations_TrainStations_TrainStationOriginId",
                table: "TicketTrainReservations",
                column: "FK_TicketTrainReservations_TrainStations_TrainStationOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrainReservations_FK_TicketTrainReservations_Transactions_TransactionId",
                table: "TicketTrainReservations",
                column: "FK_TicketTrainReservations_Transactions_TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrainReservations_TrainTravelId",
                table: "TicketTrainReservations",
                column: "TrainTravelId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrainReservations_UserId",
                table: "TicketTrainReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrainReturneds_TransactionId",
                table: "TicketTrainReturneds",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrains_FK_TicketTrains_SeatOrBeds_SeatOrBedId",
                table: "TicketTrains",
                column: "FK_TicketTrains_SeatOrBeds_SeatOrBedId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrains_PassengerId",
                table: "TicketTrains",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrains_ReturnedId",
                table: "TicketTrains",
                column: "ReturnedId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTrains_TicketTrainReservationId",
                table: "TicketTrains",
                column: "TicketTrainReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainStationConnects_FK_TrainStationConnects_TrainStations_TrainStationDestinationId",
                table: "TrainStationConnects",
                column: "FK_TrainStationConnects_TrainStations_TrainStationDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainStationConnects_FK_TrainStationConnects_TrainStations_TrainStationOriginId",
                table: "TrainStationConnects",
                column: "FK_TrainStationConnects_TrainStations_TrainStationOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainStationConnects_TrainStationOriginIdId",
                table: "TrainStationConnects",
                column: "TrainStationOriginIdId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_CityId",
                table: "TrainStations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTravels_RefundRulesId",
                table: "TrainTravels",
                column: "RefundRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTravels_TrainId",
                table: "TrainTravels",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RefrenceTypeID",
                table: "Transactions",
                column: "RefrenceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedDiscounts_DiscountId",
                table: "UsedDiscounts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedDiscounts_FK_UsedDiscounts_Transactions_NoCacade",
                table: "UsedDiscounts",
                column: "FK_UsedDiscounts_Transactions_NoCacade");

            migrationBuilder.CreateIndex(
                name: "IX_UsedDiscounts_RefrenceTypeID",
                table: "UsedDiscounts",
                column: "RefrenceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UsedDiscounts_UserId",
                table: "UsedDiscounts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirLineCompanies");

            migrationBuilder.DropTable(
                name: "AirLineContants");

            migrationBuilder.DropTable(
                name: "AirLineFinancials");

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
                name: "BusTravelServiceProviderBus");

            migrationBuilder.DropTable(
                name: "CartNumbers");

            migrationBuilder.DropTable(
                name: "FlightServiceProviderAirPlane");

            migrationBuilder.DropTable(
                name: "FlightTags");

            migrationBuilder.DropTable(
                name: "FlightTicketRefundRules");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "RouteTrainStationConnects");

            migrationBuilder.DropTable(
                name: "ServiceProviderTrainTrainTravel");

            migrationBuilder.DropTable(
                name: "TicketBuses");

            migrationBuilder.DropTable(
                name: "TicketDomesticFlights");

            migrationBuilder.DropTable(
                name: "TicketInternationalFlights");

            migrationBuilder.DropTable(
                name: "TicketTrains");

            migrationBuilder.DropTable(
                name: "TrainTicketRefundRules");

            migrationBuilder.DropTable(
                name: "UsedDiscounts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ServiceProviderBuses");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "ServiceProviderAirPlanes");

            migrationBuilder.DropTable(
                name: "TrainStationConnects");

            migrationBuilder.DropTable(
                name: "ServiceProviderTrains");

            migrationBuilder.DropTable(
                name: "TicketBusReservations");

            migrationBuilder.DropTable(
                name: "TicketBusReturneds");

            migrationBuilder.DropTable(
                name: "TicketDomesticFlightReservations");

            migrationBuilder.DropTable(
                name: "TicketDomesticFlightReturneds");

            migrationBuilder.DropTable(
                name: "TicketInternationalFlightReservations");

            migrationBuilder.DropTable(
                name: "TicketInternationalFlightReturneds");

            migrationBuilder.DropTable(
                name: "SeatOrBeds");

            migrationBuilder.DropTable(
                name: "TicketTrainReturneds");

            migrationBuilder.DropTable(
                name: "TypeServiceProviderBuses");

            migrationBuilder.DropTable(
                name: "TypeServiceProviderAirPlanes");

            migrationBuilder.DropTable(
                name: "CompanyServiceProviders");

            migrationBuilder.DropTable(
                name: "TypeServiceProviderTrains");

            migrationBuilder.DropTable(
                name: "BusTravels");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "DomesticFlights");

            migrationBuilder.DropTable(
                name: "InternationalFlights");

            migrationBuilder.DropTable(
                name: "Compartments");

            migrationBuilder.DropTable(
                name: "BusTerminals");

            migrationBuilder.DropTable(
                name: "BusTravelCompanies");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "TicketTrainReservations");

            migrationBuilder.DropTable(
                name: "BusTypes");

            migrationBuilder.DropTable(
                name: "AirLines");

            migrationBuilder.DropTable(
                name: "AirPlanes");

            migrationBuilder.DropTable(
                name: "AirplaneTerminals");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "FlightCompanies");

            migrationBuilder.DropTable(
                name: "GroupFlightTicketRefundRules");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TrainStations");

            migrationBuilder.DropTable(
                name: "TrainTravels");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AirPlaneTypes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "GroupTrainTicketRefundRules");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "RefrenceTypes");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
