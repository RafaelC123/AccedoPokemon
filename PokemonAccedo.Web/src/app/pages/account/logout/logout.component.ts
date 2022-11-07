import { Component } from "@angular/core";

@Component({
  templateUrl: 'logout.component.html',
  selector: 'app-logout'
})
export class LogoutPage
{
  constructor()
  {
    localStorage.clear();
  }
}
