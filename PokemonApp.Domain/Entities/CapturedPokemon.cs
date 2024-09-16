using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Domain.Entities
{
    public class CapturedPokemon
    {
        public int Id { get; set; }
        public int PokemonId { get; set; } 
        public string? PokemonName { get; set; } 
        public int? TreinadorId { get; set; }
        public Treinador? Treinador { get; set; } 
        public DateTime CaptureDt { get; set; }
    }
}
