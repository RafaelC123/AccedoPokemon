import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { switchMap } from "rxjs";
import { SimplePokemon } from "src/models/pokemon/pokemon-simple.model";
import { PokemonSimpleList } from "src/models/pokemon/pokemon.list.model";
import { ResponseApi } from "src/models/response.model";
import { PokemonService } from "src/services/pokemon.service";

@Component({
  templateUrl: 'dashboard.component.html',
  selector: 'app-dashboard',
})
export class DashboardPage implements OnInit
{
  public response! : ResponseApi<PokemonSimpleList>;
  public Listado : SimplePokemon[] = [];
  constructor(private pokemonService : PokemonService,private activatedRoute: ActivatedRoute,)
  {

  }
  ngOnInit(): void {
    this.activatedRoute.params.pipe(
      switchMap(() => this.pokemonService.PokemonSimpleList())
    ).subscribe((res) => {
      this.response = res
      this.Listado = res.data?.results!

      console.log(this.Listado);
    });
  }

  crypt(url : string) : string
  {
    return window.btoa(url);
  }


}
