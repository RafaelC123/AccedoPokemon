import { Observable } from "rxjs";
import { LoginRequest } from "src/models/account/request/login-request.model";
import { RegisterRequest } from "src/models/account/request/register-request.model";


export interface IAuthService
{
  ValidateLogin() : Observable<boolean>;
  LoginAsync(Creds: LoginRequest) : Observable<boolean> ;
  RegisterAsync(Creds: RegisterRequest) : Observable<boolean>;
}
