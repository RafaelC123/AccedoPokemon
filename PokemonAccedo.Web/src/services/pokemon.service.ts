import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable, of } from "rxjs";
import { environment } from "src/environments/environment.prod";
import { SimplePokemon } from "src/models/pokemon/pokemon-simple.model";
import { PokemonSprites } from "src/models/pokemon/pokemon-sprites.model";
import { PokemonSimpleList } from "src/models/pokemon/pokemon.list.model";
import { PokemonModel } from "src/models/pokemon/pokemon.model";
import { PokemonUrl } from "src/models/pokemon/request/pokemon-url.model";
import { ResponseApi } from "src/models/response.model";
import { IPokemonService } from "./interfaces/pokemon.interface";

@Injectable({
  providedIn: 'root'
})
export class PokemonService implements IPokemonService
{
  constructor(private httpClient : HttpClient) {

  }
  GetPokemon(url: string): Observable<ResponseApi<PokemonModel>> {
    let Body : PokemonUrl = new PokemonUrl();
    Body.url = url;
    console.log(Body.url);
    return this.httpClient.post<ResponseApi<PokemonModel>>(`${environment.baseUrl}Pokemon/Pokemon`, Body, {headers: new HttpHeaders({'x-version' : '1', 'Authorization' : `Bearer ${localStorage.getItem('Token')}`})});
  }


  PokemonSimpleList() : Observable<ResponseApi<PokemonSimpleList>>
  {
    return this.httpClient.get<ResponseApi<PokemonSimpleList>>(`${environment.baseUrl}Pokemon/SimpleList`,{headers: new HttpHeaders({'x-version' : '1', 'Authorization' : `Bearer ${localStorage.getItem('Token')}`  }), });
  }

}
