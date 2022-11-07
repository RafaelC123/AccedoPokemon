import { Component } from "@angular/core";

@Component({
  templateUrl: './navbar.component.html',
  selector: 'nav-navbar'
})

export class NavBarLayout
{
  public Nombre : string = `${localStorage.getItem('FirstName')} ${localStorage.getItem('SurName')}`;
}
