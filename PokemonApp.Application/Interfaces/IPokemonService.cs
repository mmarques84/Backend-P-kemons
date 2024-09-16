using PokemonApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Application.Interfaces
{
    public interface IPokemonService
    {
        Task<Pokemon> GetPokemonById(int id);
        Task<List<Pokemon>> GetRandomPokemons(int count);
        Task CapturarPokemon(int trainerId, Pokemon pokemon);
        Task<List<Pokemon>> GetCapturarPokemons(int trainerId);
        Task<Treinador> GetTrainerById(int id);
        Task CreatePokemon(Pokemon pokemon);
    }
}
