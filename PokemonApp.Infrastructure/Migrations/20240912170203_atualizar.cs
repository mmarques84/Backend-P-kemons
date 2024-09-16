using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class atualizar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Idade",
                table: "Treinadors",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Treinadors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "CapturedPokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonName = table.Column<string>(type: "TEXT", nullable: false),
                    TreinadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CaptureDt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapturedPokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapturedPokemons_Treinadors_TreinadorId",
                        column: x => x.TreinadorId,
                        principalTable: "Treinadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonEvolucoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonEvolucoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonEvolucoes_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapturedPokemons_TreinadorId",
                table: "CapturedPokemons",
                column: "TreinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonEvolucoes_PokemonId",
                table: "PokemonEvolucoes",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapturedPokemons");

            migrationBuilder.DropTable(
                name: "PokemonEvolucoes");

            migrationBuilder.AlterColumn<int>(
                name: "Idade",
                table: "Treinadors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Treinadors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
