using Microsoft.EntityFrameworkCore;
using PokemonApp.Domain.Entities;

namespace PokemonApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Defina os DbSets para suas entidades, como Pokemons e Trainers
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Treinador> Treinadors { get; set; }
        public DbSet<CapturedPokemon> CapturedPokemons { get; set; }
        public DbSet<PokemonEvolucao> PokemonEvolucoes{ get; set; }

     
    }
}
