using Microsoft.EntityFrameworkCore.Migrations;

namespace cis174projects.Migrations.Ticket
{
    public partial class Ticket : Migration
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    SprintNumber = table.Column<string>(nullable: false),
                    PointValue = table.Column<string>(nullable: false),
                    StatusId = table.Column<string>(nullable: false),
                    TicketId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_TicketsP_TicketsP_TicketId",
                        column: x => x.TicketId,
                        principalTable: "TicketsP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "TicketsP",
                columns: new[] { "Id", "Description", "Name", "PointValue", "SprintNumber", "StatusId", "TicketId" },
                values: new object[] { 1, "Testing out seeding valuse", "Seeding ticket with database", "1", "100", "todo", null });

            migrationBuilder.CreateIndex(
                name: "IX_TicketsP_StatusId",
                table: "TicketsP",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsP_TicketId",
                table: "TicketsP",
                column: "TicketId");
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
