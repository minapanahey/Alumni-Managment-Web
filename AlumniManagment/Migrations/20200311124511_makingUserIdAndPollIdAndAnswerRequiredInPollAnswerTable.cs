using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniManagment.Migrations
{
    public partial class makingUserIdAndPollIdAndAnswerRequiredInPollAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pollAnswers_AspNetUsers_UserId",
                table: "pollAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "pollAnswers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "pollAnswers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pollAnswers_AspNetUsers_UserId",
                table: "pollAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pollAnswers_AspNetUsers_UserId",
                table: "pollAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "pollAnswers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "pollAnswers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_pollAnswers_AspNetUsers_UserId",
                table: "pollAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
