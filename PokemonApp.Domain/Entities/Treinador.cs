using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Domain.Entities
{
    public class Treinador
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public string? Cpf { get; set; }
        public List<CapturedPokemon>? CapturedPokemons{ get; set; }
    }
}
