using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace cis174projects.Migrations.Ticket
{
    public partial class ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusesP",
                columns: table => new
                {
                    StatusId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusesP", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TicketsP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation(
                        "SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable:false),
                    Description = table.Column<string>(nullable: false),
                    SprintNumber = table.Column<string>(nullable:false),
                    PointValue = table.Column<string>(nullable:false),
                    StatusId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketsP_StatusesP_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusesP",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StatusesP",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { "todo", "To Do" },
                    { "inprogress", "In Progress" },
                    { "qa", "Quality Assurance" },
                    { "done", "Done" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketsP_StatusId",
                table: "TicketsP",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketsP");

            migrationBuilder.DropTable(
                name: "StatusesP");
        }
    }
}
