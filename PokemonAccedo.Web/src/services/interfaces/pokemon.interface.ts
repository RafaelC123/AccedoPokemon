import { Observable } from "rxjs";
import { SimplePokemon } from "src/models/pokemon/pokemon-simple.model";
import { PokemonSimpleList } from "src/models/pokemon/pokemon.list.model";
import { PokemonModel } from "src/models/pokemon/pokemon.model";
import { ResponseApi } from "src/models/response.model";

export interface IPokemonService
{
  PokemonSimpleList() : Observable<ResponseApi<PokemonSimpleList>>;
  GetPokemon(url : string) : Observable<ResponseApi<PokemonModel>>;
}
