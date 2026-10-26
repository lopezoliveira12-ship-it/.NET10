using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiJogos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Genero = table.Column<string>(type: "TEXT", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "Id", "Ano", "Genero", "Nome" },
                values: new object[,]
                {
                    { 1, 2011, "Sandbox", "Minecraft" },
                    { 2, 2024, "Esportes", "FIFA 25" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
