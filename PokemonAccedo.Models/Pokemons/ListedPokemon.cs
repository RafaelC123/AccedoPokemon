using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccedo.Models.Pokemons
{
    public class ListedPokemon
    {
        public int Count { get; set; }

        //No usare la paginacion para consumir menos tiempo en el desarrollo, pero esta la opcion por si requieren que lo maneje
        public string Next { get; set; }
        public string Previous { get; set; }

        public List<SimplePokemon> results { get; set; }
    }
}
