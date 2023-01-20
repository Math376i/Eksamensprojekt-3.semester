import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree} from "@angular/router";
import {Observable} from "rxjs";
import jwtDecode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthguardService implements CanActivate{

  constructor() { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let token = localStorage.getItem('token')
    if(token){
      return true;
    } else{
      return false;
    }
    if(token){
    // @ts-ignore
      let decodedToken = jwtDecode(token) as Token;
    let currentDate = new Date();
    if(decodedToken.exp) {
      // @ts-ignore
      let expiry = new Date(decodedToken.exp * 1000);

      if (currentDate > expiry) {
        return true;
      }
    }
    }
return false;
  }

}
class Token{
  exp? : number;

}
