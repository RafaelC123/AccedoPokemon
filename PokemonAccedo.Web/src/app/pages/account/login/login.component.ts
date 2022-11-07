import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/models/account/request/login-request.model';
import { AuthService } from 'src/services/auth.service';


@Component({
  selector: 'app-login-page',
  templateUrl: './login.component.html',

})
export class LoginPage implements OnInit {

  public loginRequest : LoginRequest;
  public Message : string  | null = null;
  public Errors : string = "";

  constructor(private router: Router, private authService : AuthService ) {
    this.loginRequest = new LoginRequest();
   }

  ngOnInit(): void {
  }

  Login() : void
  {
    this.Message = "Un momento por favor";
    this.authService.LoginAsync(this.loginRequest)
    .subscribe((res : any) => {
      console.log(res);
      if(res){
        this.router.navigate(['/']);
      }
      else {
        this.Message = null;
        this.Errors = "Credenciales incorrectas";
      }
    });

  }

}
