using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniManagment.Migrations
{
    public partial class AddingCalendarIdToPOllsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "calendarId",
                table: "polls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_polls_calendarId",
                table: "polls",
                column: "calendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_polls_Calandar_calendarId",
                table: "polls",
                column: "calendarId",
                principalTable: "Calandar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_polls_Calandar_calendarId",
                table: "polls");

            migrationBuilder.DropIndex(
                name: "IX_polls_calendarId",
                table: "polls");

            migrationBuilder.DropColumn(
                name: "calendarId",
                table: "polls");
        }
    }
}
