using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Domain.Entities
{
    public class PokemonEvolucao
    {
        public int Id { get; set; }
        public string? Nome { get; set; } 
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
