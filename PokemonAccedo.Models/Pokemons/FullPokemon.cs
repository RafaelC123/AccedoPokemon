using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccedo.Models.Pokemons
{
    public class FullPokemon
    {
        public List<AbilitiesPokemon> Abilities { get; set; }
        public string Name { get; set; }
        public SpritesPokemon Sprites { get; set; }
    }
}
