using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarKnightAndJoker.Server.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosRegistrosInicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userNameDark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailDark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passworDark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRegistrosInicios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosRegistrosInicios");
        }
    }
}
