using Microsoft.AspNetCore.Mvc;
using PokemonApp.Application.Interfaces;
using PokemonApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // GET: api/Pokemon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemonById(int id)
        {
            var pokemon = await _pokemonService.GetPokemonById(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return Ok(pokemon);
        }

        // GET: api/Pokemon/random/10
        [HttpGet("random/{count}")]
        public async Task<ActionResult<List<Pokemon>>> GetRandomPokemons(int count)
        {
            var pokemons = await _pokemonService.GetRandomPokemons(count);
            return Ok(pokemons);
        }

        // POST: api/Pokemon/capture
        [HttpPost("capture")]
        public async Task<IActionResult> CapturePokemon([FromBody] CaptureRequest request)
        {
            await _pokemonService.CapturarPokemon(request.TrainerId, request.Pokemon);
            return Ok();
        }

        // GET: api/Pokemon/captured/5
        [HttpGet("captured/{trainerId}")]
        public async Task<ActionResult<List<Pokemon>>> GetCapturedPokemons(int trainerId)
        {
            var pokemons = await _pokemonService.GetCapturarPokemons(trainerId);
            return Ok(pokemons);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePokemon([FromBody] Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return BadRequest("Pokémon data is required.");
            }

            await _pokemonService.CreatePokemon(pokemon);
            return CreatedAtAction(nameof(GetPokemonById), new { id = pokemon.Id }, pokemon);
        }
    }

    public class CaptureRequest
    {
        public int TrainerId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
