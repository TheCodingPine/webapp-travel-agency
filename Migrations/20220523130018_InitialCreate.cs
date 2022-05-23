using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PacchettiViaggio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePacchetto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<int>(type: "int", nullable: false),
                    url_pack = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacchettiViaggio", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacchettiViaggio_NomePacchetto",
                table: "PacchettiViaggio",
                column: "NomePacchetto",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacchettiViaggio");
        }
    }
}
