import { Abilities } from "./pokemon-abilities.model";
import { PokemonSprites } from "./pokemon-sprites.model";

export class PokemonModel
{
  public abilities! : Abilities[];
  public name! : string;
  public sprites! : PokemonSprites;
}
