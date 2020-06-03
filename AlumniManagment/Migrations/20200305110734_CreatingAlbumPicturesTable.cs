using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniManagment.Migrations
{
    public partial class CreatingAlbumPicturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumPictures",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    picture = table.Column<string>(nullable: false),
                    albumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumPictures", x => x.id);
                    table.ForeignKey(
                        name: "FK_AlbumPictures_Albums_albumId",
                        column: x => x.albumId,
                        principalTable: "Albums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumPictures_albumId",
                table: "AlbumPictures",
                column: "albumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumPictures");
        }
    }
}
