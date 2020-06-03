using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniManagment.Migrations
{
    public partial class CreatingAccountPrivacyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountPrivacy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    facebookIsPublic = table.Column<bool>(nullable: false),
                    instagramIsPublic = table.Column<bool>(nullable: false),
                    twitterIsPublic = table.Column<bool>(nullable: false),
                    phoneIsPublic = table.Column<bool>(nullable: false),
                    emailIsPublic = table.Column<bool>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPrivacy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountPrivacy_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPrivacy_userId",
                table: "AccountPrivacy",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPrivacy");
        }
    }
}
