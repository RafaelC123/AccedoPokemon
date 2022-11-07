import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { IAuthService } from "./interfaces/auth.interface";
import { ResponseApi } from "../models/response.model";
import { LoginRequest } from "../models/account/request/login-request.model";
import { environment } from "src/environments/environment.prod";
import { map, Observable, of } from "rxjs";
import { RegisterRequest } from "src/models/account/request/register-request.model";

@Injectable({
  providedIn: 'root'
})

export class AuthService implements IAuthService
{

  private Base : string = environment.baseUrl;
  constructor(private Client : HttpClient)
  {}



  ValidateLogin(): Observable<boolean> {
    if(localStorage.getItem("Token") != null)
      return of(true);

    return of(false);
  }

  LoginAsync(Creds: LoginRequest) : Observable<boolean> {
      return this.Client.post<any>(`${this.Base}Account/Login`,Creds, {headers: new HttpHeaders({'x-version' : '1'})})
      .pipe(
        map(data => {
          if(data != null && data.data != null)
          {
            localStorage.setItem("Token", data.data.token);
            localStorage.setItem("FirstName", data.data.name);
            localStorage.setItem("SurName", data.data.surName);
            return true;
          }
          else{
            return false;
          }
        })
      );
  }
  RegisterAsync(Creds: RegisterRequest) : Observable<boolean> {
    return this.Client.post<any>(`${this.Base}Account/Register`,Creds, {headers: new HttpHeaders({'x-version' : '1'})})
      .pipe(
        map(data => {
          if(data.isSuccess)
            return true;

          return false;
        })
      );
  }



}
