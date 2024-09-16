using Microsoft.EntityFrameworkCore;
using PokemonApp.Application.Interfaces;
using PokemonApp.Domain.Entities;
using PokemonApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Application.Services
{
    public class TreinadorService : ITreinadorService
    {
        private readonly ApplicationDbContext _context;

        public TreinadorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Treinador> GetTreinadorById(int id)
        {
            return await _context.Treinadors
                .Include(t => t.CapturedPokemons)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Treinador>> GetAllTreinadores()
        {
            return await _context.Treinadors
                .Include(t => t.CapturedPokemons)
                .ToListAsync();
        }

        public async Task CreateTreinador(Treinador treinador)
        {
            _context.Treinadors.Add(treinador);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CapturedPokemon>> GetPokemonsCapturados(int treinadorId)
        {
            var treinador = await _context.Treinadors
                .Include(t => t.CapturedPokemons)
                .FirstOrDefaultAsync(t => t.Id == treinadorId);

            return treinador?.CapturedPokemons;
        }
    }
}
