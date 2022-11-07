import { Component, NgModule, ViewChildren } from "@angular/core";
import { Route, RouterModule, Routes } from "@angular/router";
import { AuthSuccess } from "src/guards/auth-success.guard";
import { LoginPage } from "./login/login.component";
import { LogoutPage } from "./logout/logout.component";
import { RegisterPage } from "./register/register.component";


const routes : Routes = [
  {
    path: 'account',
    children: [
      {
        path: 'login',
        component: LoginPage,
        canLoad: [AuthSuccess],
        canActivate: [AuthSuccess]
      },
      {
        path: 'register',
        component: RegisterPage,
        canLoad: [AuthSuccess],
        canActivate: [AuthSuccess]
      },
      {
        path: 'logout',
        component: LogoutPage,
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule{}
