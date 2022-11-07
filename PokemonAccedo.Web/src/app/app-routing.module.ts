import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';
import { DashboardPage } from './pages/dashboard/dashboard.component';
import { PokemonPage } from './pages/pokemon/pokemon.component';

const routes: Routes = [
  {
    path: '',
    component : DashboardPage,
    canLoad: [ AuthGuard ],
    canActivate: [ AuthGuard ]
  },
  {
    path: 'pokemon/:id',
    component: PokemonPage,
    canLoad: [ AuthGuard ],
    canActivate: [ AuthGuard ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
