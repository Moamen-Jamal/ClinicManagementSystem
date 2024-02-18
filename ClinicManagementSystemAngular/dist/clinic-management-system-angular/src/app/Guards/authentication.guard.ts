import { Inject, Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, UrlTree } from '@angular/router';
import { UserService } from '../Shared/User/user.service';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { DOCUMENT } from '@angular/common';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationGuard{
  localStorage: any;
  constructor(@Inject(DOCUMENT) private document: Document,private router : Router ,private userService :UserService, private toastr: ToastrService){
    this.localStorage = document.defaultView?.localStorage;
  }
  canActivate(next: ActivatedRouteSnapshot):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
      if (this.localStorage?.getItem('userToken')){
      
        let roles = next.data['permittedRoles'] as [];
        if(roles){
          if(this.userService.roleMatch(roles)) return true;
          else{
            this.router.navigate(['/forbidden']);
            return false;
          }
        }
        return true;
      }
      else
      {
      this.toastr.error('Please Log In!');
      this.router.navigate(['/Login']);
      return false;
   }
  }
}
