import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from "rxjs/operators";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { DOCUMENT } from '@angular/common';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    localStorage: any;
    constructor(@Inject(DOCUMENT) private document: Document,private router: Router) {
        this.localStorage = document.defaultView?.localStorage;
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.localStorage?.getItem('userToken') != null) {
            const clonedReq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + this.localStorage?.getItem('userToken'))
            });
            return next.handle(clonedReq).pipe(
                tap(
                    succ => { },
                    err => {
                        if (err.status == 401){
                            this.localStorage?.removeItem('userToken');
                            this.router.navigateByUrl('/user/login');
                        }
                        else if(err.status == 403)
                        this.router.navigateByUrl('/forbidden');
                        
                    }
                )
            )
        }
        else
            return next.handle(req.clone());
    }
}
