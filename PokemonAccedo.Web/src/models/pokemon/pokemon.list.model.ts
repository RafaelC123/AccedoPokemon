import { SimplePokemon } from "./pokemon-simple.model";

export class PokemonSimpleList{
  public count : number = 0;
  public next : string = "";
  public previous : string = "";
  public results : SimplePokemon[] = [];
}
