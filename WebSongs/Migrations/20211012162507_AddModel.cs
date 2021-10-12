using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSongs.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    NombreCancion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Enlace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.NombreCancion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");
        }
    }
}
