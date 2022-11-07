import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, CanLoad, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from "@angular/router";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanLoad, CanActivate
{

  constructor(
    private router: Router
    ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if(localStorage.getItem('Token') != null)
      return true;

    this.router.navigate(['account/login']);
    return false;
  }
  canLoad(route: Route, segments: UrlSegment[]): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree>
  {
    if(localStorage.getItem('token') != null)
      return true;

    this.router.navigate(['account/login']);
    return false;
  }

}
