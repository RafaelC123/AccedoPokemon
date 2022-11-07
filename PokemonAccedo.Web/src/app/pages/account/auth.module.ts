import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { AuthRoutingModule } from "./auth.routing.module";
import { LoginPage } from "./login/login.component";
import { LogoutPage } from "./logout/logout.component";
import { RegisterPage } from "./register/register.component";


@NgModule({
  declarations: [
    LoginPage,
    RegisterPage,
    LogoutPage
  ],
  exports: [
    LoginPage,
    RegisterPage,
    LogoutPage
  ],
  imports: [
    AuthRoutingModule,
    FormsModule,
    CommonModule
  ]
})
export class AuthenModule
{

}
