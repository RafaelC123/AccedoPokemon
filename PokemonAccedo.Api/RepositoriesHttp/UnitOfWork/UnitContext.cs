using PokemonAccedo.Api.RepositoriesHttp.Repositories;
using PokemonAccedo.Models.Pokemons;

namespace PokemonAccedo.Api.RepositoriesHttp.UnitOfWork
{
    public class UnitContext
    {
        public UnitContext(RepositoryGeneric<ListedPokemon> GetList, RepositoryGeneric<FullPokemon> GetPokemon)
        {
            this.GetList = GetList;
            this.GetPokemon = GetPokemon;
        }
        public RepositoryGeneric<ListedPokemon> GetList { get; set; }
        public RepositoryGeneric<FullPokemon> GetPokemon { get; set; }
        
    }
}
