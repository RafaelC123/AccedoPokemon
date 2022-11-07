import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { switchMap } from "rxjs";
import { Action } from "rxjs/internal/scheduler/Action";
import { PokemonModel } from "src/models/pokemon/pokemon.model";
import { ResponseApi } from "src/models/response.model";
import { PokemonService } from "src/services/pokemon.service";

@Component({
  selector: 'page-pokemon',
  templateUrl: './pokemon.component.html'
})
export class PokemonPage implements OnInit
{
  public Pokemon! : ResponseApi<PokemonModel>;
  constructor(private routeParams : ActivatedRoute, private pokemonService : PokemonService){}


  ngOnInit(): void {
    this.routeParams.params.pipe(
      switchMap((Params : any) => this.pokemonService.GetPokemon(window.atob(Params.id)))
    ).subscribe(data => {
      this.Pokemon = data;
      console.log(this.Pokemon);
      console.log(this.Pokemon.data?.sprites);
    });
  }
}
