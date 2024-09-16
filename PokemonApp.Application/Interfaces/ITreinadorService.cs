using PokemonApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Application.Interfaces
{
    public interface ITreinadorService
    {
        Task<Treinador> GetTreinadorById(int id);
        Task<List<Treinador>> GetAllTreinadores();
        Task CreateTreinador(Treinador treinador);
        Task<List<CapturedPokemon>> GetPokemonsCapturados(int treinadorId);
    }
}
