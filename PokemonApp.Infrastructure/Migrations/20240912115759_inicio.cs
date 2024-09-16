using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treinadors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinadors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    SpriteBase64 = table.Column<string>(type: "TEXT", nullable: false),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: true),
                    TreinadorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pokemons_Treinadors_TreinadorId",
                        column: x => x.TreinadorId,
                        principalTable: "Treinadors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_PokemonId",
                table: "Pokemons",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_TreinadorId",
                table: "Pokemons",
                column: "TreinadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Treinadors");
        }
    }
}
