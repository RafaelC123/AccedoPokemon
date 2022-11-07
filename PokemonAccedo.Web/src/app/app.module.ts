import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { AuthenModule } from './pages/account/auth.module';
import { NavBarLayout } from './layouts/navbar/navbar.component';
import { DashboardPage } from './pages/dashboard/dashboard.component';
import { PokemonPage } from './pages/pokemon/pokemon.component';


@NgModule({
  declarations: [
    AppComponent,
    NavBarLayout,
    DashboardPage,
    PokemonPage
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    AuthenModule,
    CommonModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule
{

}
