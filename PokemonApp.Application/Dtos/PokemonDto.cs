using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Application.Dtos
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public SpritesDto? Sprites { get; set; }
        public SpeciesDto? Species { get; set; }
    }
    public class SpritesDto
    {
        public string? FrontDefault { get; set; }
    }

    public class SpeciesDto
    {
        public string? Url { get; set; }
        public EvolutionChainDto? EvolutionChain { get; set; }
    }

    public class EvolutionChainDto
    {
        public EvolutionDto? Chain { get; set; }
    }

    public class EvolutionDto
    {
        public SpeciesDto? Species { get; set; }
        public List<EvolutionDto>? EvolvesTo { get; set; }
    }
}
