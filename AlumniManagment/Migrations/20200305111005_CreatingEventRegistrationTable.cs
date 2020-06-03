using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniManagment.Migrations
{
    public partial class CreatingEventRegistrationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDinner = table.Column<bool>(nullable: false),
                    isShirt = table.Column<bool>(nullable: false),
                    eventId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    paymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventRegistration", x => x.id);
                    table.ForeignKey(
                        name: "FK_eventRegistration_Events_eventId",
                        column: x => x.eventId,
                        principalTable: "Events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventRegistration_Payments_paymentId",
                        column: x => x.paymentId,
                        principalTable: "Payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventRegistration_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventRegistration_eventId",
                table: "eventRegistration",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_eventRegistration_paymentId",
                table: "eventRegistration",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_eventRegistration_userId",
                table: "eventRegistration",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventRegistration");
        }
    }
}
