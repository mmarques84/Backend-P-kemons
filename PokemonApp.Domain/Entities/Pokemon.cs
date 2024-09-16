using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Domain.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SpriteBase64 { get; set; }
        public List<string>? Evolucoes { get; set; }
    }
}
