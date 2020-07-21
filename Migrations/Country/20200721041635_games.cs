using Microsoft.EntityFrameworkCore.Migrations;

namespace cis174projects.Migrations.Country
{
    public partial class games : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportID = table.Column<string>(nullable: false),
                    SportName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SportID = table.Column<string>(nullable: true),
                    SportName = table.Column<string>(nullable: true),
                    LogoImage = table.Column<string>(nullable: true),
                    GameID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { "Winter", "Winter Olympics" },
                    { "Summer", "Summer Olympics" },
                    { "Paralympics", "Paralympics" },
                    { "Youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportID", "SportName" },
                values: new object[,]
                {
                    { "Curling", "Indoor" },
                    { "Bobsleigh", "Outdoor" },
                    { "Diving", "Indoor" },
                    { "Road Cycling", "Outdoor" },
                    { "Archery", "Indoor" },
                    { "Canoe Sprint", "Outdoor" },
                    { "Breakdancing", "Indoor" },
                    { "Skateboarding", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "GameID", "LogoImage", "Name", "SportID", "SportName" },
                values: new object[,]
                {
                    { "ca", "Winter", "ca.png", "Canada", "Curling", null },
                    { "fi", "Youth", "fi.png", "Finland", "Skateboarding", null },
                    { "ru", "Youth", "ru.png", "Russia", "Breakdancing", null },
                    { "cy", "Youth", "cy.png", "Cyprus", "Breakdancing", null },
                    { "fr", "Youth", "fr.png", "France", "Breakdancing", null },
                    { "zw", "Paralympics", "zw.png", "Zimbabwe", "Canoe Sprint", null },
                    { "pk", "Paralympics", "pk.png", "Pakistan", "Canoe Sprint", null },
                    { "at", "Paralympics", "at.png", "Austria", "Canoe Sprint", null },
                    { "ua", "Paralympics", "ua.png", "Ukraine", "Archery", null },
                    { "uy", "Paralympics", "uy.png", "Uruguay", "Archery", null },
                    { "th", "Paralympics", "th.png", "Thailand", "Archery", null },
                    { "us", "Summer", "us.png", "USA", "Road Cycling", null },
                    { "nl", "Summer", "nl.png", "Netherlands", "Road Cycling", null },
                    { "br", "Summer", "br.png", "Brazil", "Road Cycling", null },
                    { "mx", "Summer", "mx.png", "Mexico", "Diving", null },
                    { "cn", "Summer", "cn.png", "China", "Diving", null },
                    { "de", "Summer", "de.png", "Germany", "Diving", null },
                    { "jp", "Winter", "jp.png", "Japan", "Bobsleigh", null },
                    { "it", "Winter", "it.png", "Italy", "Bobsleigh", null },
                    { "jm", "Winter", "jm.png", "Jamaica", "Bobsleigh", null },
                    { "gb", "Winter", "gb.png", "Great Britain", "Curling", null },
                    { "se", "Winter", "se.png", "Sweden", "Curling", null },
                    { "sk", "Youth", "sk.png", "Slovakia", "Skateboarding", null },
                    { "pt", "Youth", "pt.png", "Portugal", "Skateboarding", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportID",
                table: "Countries",
                column: "SportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
