using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PokemonApp.Application.Dtos;
using PokemonApp.Application.Interfaces;
using PokemonApp.Domain.Entities;
using PokemonApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ApplicationDbContext _context;
        public PokemonService(IHttpClientFactory clientFactory, ApplicationDbContext context)
        {
            _clientFactory = clientFactory;
            _context = context;
        }
        public async Task CapturarPokemon(int trainerId, Pokemon pokemon)
        {

            var treinador = await _context.Treinadors
                .Include(t => t.CapturedPokemons)
                .FirstOrDefaultAsync(t => t.Id == trainerId);

            if (treinador == null)
            {
                throw new Exception("Treinador não encontrado.");
            }

            // Criar a entidade CapturedPokemon
            var capturedPokemon = new CapturedPokemon
            {
                PokemonId = pokemon.Id,
                PokemonName = pokemon.Nome,
                TreinadorId = trainerId,
                CaptureDt = DateTime.Now
            };

            // Adicionar o Pokémon capturado à lista do treinador
            treinador.CapturedPokemons.Add(capturedPokemon);

            // Salvar as alterações no banco de dados
            _context.Treinadors.Update(treinador);
            await _context.SaveChangesAsync();
        }

        public Task<List<Pokemon>> GetCapturarPokemons(int trainerId)
        {
            throw new NotImplementedException();
        }
        private string ConvertToBase64(string imageUrl)
        {
            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(imageUrl);
                return Convert.ToBase64String(imageBytes);
            }
        }
        public async Task<Pokemon> GetPokemonById(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();


                var pokemon = JsonConvert.DeserializeObject<PokemonDto>(content);


                return new Pokemon
                {
                    Id = pokemon.Id,
                    //Name = pokemon.Name,
                    //Base64Sprite = ConvertToBase64(pokemon.Sprites.FrontDefault),
                    //Evolutions = await GetPokemonEvolutions(pokemon.Species.Url)
                };
            }
            return null;
        }

        public async Task<List<Pokemon>> GetRandomPokemons(int count)
        {
            var random = new Random();
            var pokemons = new List<Pokemon>();

            for (int i = 0; i < count; i++)
            {
                int randomId = random.Next(1, 10);
                var pokemon = await GetPokemonById(randomId);
                if (pokemon != null)
                {
                    pokemons.Add(pokemon);
                }
            }
            return pokemons;

        }
        public async Task CapturePokemon(int pokemonId, int treinadorId, string trainerName)
        {

            var pokemon = await GetPokemonById(pokemonId);

            if (pokemon != null)
            {
                var capturedPokemon = new CapturedPokemon
                {
                    PokemonId = pokemon.Id,
                    PokemonName = pokemon.Nome, // Corrigido para usar 'pokemon.Name'
                    TreinadorId = treinadorId,
                    CaptureDt = DateTime.Now
                };

                _context.CapturedPokemons.Add(capturedPokemon);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<CapturedPokemon>> GetCapturedPokemons(string trainerName)
        {

            return await _context.CapturedPokemons
                .Where(p => p.Treinador.Nome == trainerName)
                .ToListAsync();
        }

        public async Task<Treinador> GetTrainerById(int id)
        {
            return await _context.Treinadors
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
        }
        public async Task CreatePokemon(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();
        }
    }
}
