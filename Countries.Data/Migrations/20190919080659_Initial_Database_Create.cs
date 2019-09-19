using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Countries.Data.Migrations
{
    public partial class Initial_Database_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Iso639_1 = table.Column<string>(nullable: true),
                    Iso639_2 = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NativeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionalBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Acronym = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionalBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeZones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    De = table.Column<string>(nullable: true),
                    Es = table.Column<string>(nullable: true),
                    Fr = table.Column<string>(nullable: true),
                    Ja = table.Column<string>(nullable: true),
                    It = table.Column<string>(nullable: true),
                    Br = table.Column<string>(nullable: true),
                    Pt = table.Column<string>(nullable: true),
                    Nl = table.Column<string>(nullable: true),
                    Hr = table.Column<string>(nullable: true),
                    Fa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Alpha2Code = table.Column<string>(nullable: true),
                    Aplha3Code = table.Column<string>(nullable: true),
                    Capital = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    SubRegion = table.Column<string>(nullable: true),
                    Population = table.Column<double>(nullable: false),
                    CoordinatesId = table.Column<int>(nullable: false),
                    Demonym = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: true),
                    Gini = table.Column<double>(nullable: true),
                    NativeName = table.Column<string>(nullable: true),
                    NumericCode = table.Column<string>(nullable: true),
                    TranslationsId = table.Column<int>(nullable: false),
                    FlagUrl = table.Column<string>(nullable: true),
                    Cioc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Coordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Translations_TranslationsId",
                        column: x => x.TranslationsId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlternativeSpellings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeSpellings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeSpellings_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallingCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallingCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallingCodes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryBorder",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    BorderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryBorder", x => new { x.CountryId, x.BorderId });
                    table.ForeignKey(
                        name: "FK_CountryBorder_Borders_BorderId",
                        column: x => x.BorderId,
                        principalTable: "Borders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryBorder_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryCurrency",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrency", x => new { x.CountryId, x.CurrencyId });
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryLanguage",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLanguage", x => new { x.CountryId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CountryLanguage_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegionalBlock",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    RegionalBlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegionalBlock", x => new { x.CountryId, x.RegionalBlockId });
                    table.ForeignKey(
                        name: "FK_CountryRegionalBlock_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryRegionalBlock_RegionalBlocks_RegionalBlockId",
                        column: x => x.RegionalBlockId,
                        principalTable: "RegionalBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTimeZone",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    TimeZoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTimeZone", x => new { x.CountryId, x.TimeZoneId });
                    table.ForeignKey(
                        name: "FK_CountryTimeZone_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTimeZone_TimeZones_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternetDomains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetDomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternetDomains_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeSpellings_CountryId",
                table: "AlternativeSpellings",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CallingCodes_CountryId",
                table: "CallingCodes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CoordinatesId",
                table: "Countries",
                column: "CoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_TranslationsId",
                table: "Countries",
                column: "TranslationsId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryBorder_BorderId",
                table: "CountryBorder",
                column: "BorderId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrency_CurrencyId",
                table: "CountryCurrency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLanguage_LanguageId",
                table: "CountryLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryRegionalBlock_RegionalBlockId",
                table: "CountryRegionalBlock",
                column: "RegionalBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTimeZone_TimeZoneId",
                table: "CountryTimeZone",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetDomains_CountryId",
                table: "InternetDomains",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlternativeSpellings");

            migrationBuilder.DropTable(
                name: "CallingCodes");

            migrationBuilder.DropTable(
                name: "CountryBorder");

            migrationBuilder.DropTable(
                name: "CountryCurrency");

            migrationBuilder.DropTable(
                name: "CountryLanguage");

            migrationBuilder.DropTable(
                name: "CountryRegionalBlock");

            migrationBuilder.DropTable(
                name: "CountryTimeZone");

            migrationBuilder.DropTable(
                name: "InternetDomains");

            migrationBuilder.DropTable(
                name: "Borders");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "RegionalBlocks");

            migrationBuilder.DropTable(
                name: "TimeZones");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Translations");
        }
    }
}
