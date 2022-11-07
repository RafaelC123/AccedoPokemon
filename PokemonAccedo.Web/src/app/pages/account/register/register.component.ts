import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { RegisterRequest } from "src/models/account/request/register-request.model";
import { AuthService } from "src/services/auth.service";


@Component({
  templateUrl: './register.component.html',
  selector: 'app-register-page'
})

export class RegisterPage
{
  public user : RegisterRequest;
  public Message : string | null = null;
  public Load : string | null = null;
  public Errors : string = "";
    constructor(private router: Router, private authService : AuthService)
    {
      this.user = new RegisterRequest();
    }

    Register()
    {
      this.Errors = "";
      this.Message = null;
      this.Load = "Un momento...";
      this.authService.RegisterAsync(this.user)
      .subscribe((res : any) => {
        if(res)
        {
          console.log("Ok");
          this.Message = "Usuario registrado correctamente";
        }
        else {
          this.Errors = "Ha ocurrido un error";
          this.Load = null;
        }
      });
      this.Load = null;
    }

}
