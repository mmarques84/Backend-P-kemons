using Microsoft.AspNetCore.Mvc;
using PokemonApp.Application.Interfaces;
using PokemonApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinadorController : ControllerBase
    {
        private readonly ITreinadorService _treinadorService;

        public TreinadorController(ITreinadorService treinadorService)
        {
            _treinadorService = treinadorService;
        }

        // GET: api/treinador
        [HttpGet]
        public async Task<ActionResult<List<Treinador>>> GetAllTreinadores()
        {
            var treinadores = await _treinadorService.GetAllTreinadores();
            return Ok(treinadores);
        }

        // GET: api/treinador/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Treinador>> GetTreinadorById(int id)
        {
            var treinador = await _treinadorService.GetTreinadorById(id);
            if (treinador == null)
            {
                return NotFound();
            }

            return Ok(treinador);
        }

        // POST: api/treinador
        [HttpPost]
        public async Task<ActionResult> CreateTreinador([FromBody] Treinador treinador)
        {
            if (treinador == null)
            {
                return BadRequest();
            }

            await _treinadorService.CreateTreinador(treinador);
            return CreatedAtAction(nameof(GetTreinadorById), new { id = treinador.Id }, treinador);
        }

        // GET: api/treinador/{id}/pokemons
        [HttpGet("{id}/pokemons")]
        public async Task<ActionResult<List<Pokemon>>> GetPokemonsCapturados(int id)
        {
            var pokemons = await _treinadorService.GetPokemonsCapturados(id);
            if (pokemons == null)
            {
                return NotFound();
            }

            return Ok(pokemons);
        }
    }
}
