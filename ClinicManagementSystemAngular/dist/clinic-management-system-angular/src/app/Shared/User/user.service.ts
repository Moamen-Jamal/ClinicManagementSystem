import { Inject, Injectable } from '@angular/core';
import {HttpClient, HttpHeaders}from '@angular/common/http'
import { environment } from '../../../environments/environment';
import { map, tap } from 'rxjs/operators';
import { DOCUMENT } from '@angular/common';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  localStorage: any;
  reqHeader: any;
  constructor(@Inject(DOCUMENT) private document: Document,private http: HttpClient) { 
    this.localStorage = document.defaultView?.localStorage;
    this.reqHeader = new HttpHeaders(
      {
        'Content-Type' : 'application/json; charset=utf-8',
        'Accept'       : 'application/json', 
        //'Authorization' :'Bearer ' + this.localStorage?.getItem("userToken")
      });
  }
  
  UserAuthentication(username:any , password:any){
    var data = {
      UserName:username,
      Password:password
    }; 
    var reqHeader = new HttpHeaders({'Content-Type' : 'application/json; charset=utf-8',
    'Accept'       : 'application/json', });
    return this.http.post(environment.apiURL+'User/Login',data ,{headers : reqHeader})
  }

  roleMatch(allowedRoles: []): boolean {
    var isMatch = false;
    const userToken = this.localStorage?.getItem('userToken');
    const payLoad = JSON.parse(window.atob(userToken ? userToken.split('.')[1] : '{}'));
    if(payLoad != '{}'){
      var userRole = payLoad.Roles;
      allowedRoles.forEach(element => {
        if (userRole == element) {
          isMatch = true;
          //return false;
        }
      });
    }
    return isMatch;
  }
  getUser(id :number){
    return this.http.get(environment.apiURL+"User/Get/"+id,{headers : this.reqHeader})
  }


  /////////////////////////////
  ////// For Validation ///////

  // getUsers() {
  //   return this.http.get<any[]>(environment.apiURL+`User/Get`,{headers : this.reqHeader}).pipe(
  //     map(users => {
  //       const newUsers = [];
  //       for (let user of users) {
  //         const email = user.Email;
  //         const userName = user.UserName;
  //         newUsers.push({ email: email, userName: userName });
  //       }
  //       return newUsers;
  //     }),
  //     tap(users => console.log(users))
  //   );
  // }


  // getUserByEmail(email: string) {
  //   return this.http.get<any[]>(environment.apiURL+`User/Get?Email=${email}`,{headers : this.reqHeader});
  // }

  // getUserByUsername(userName: string) {
  //   return this.http.get<any[]>(environment.apiURL+`User/Get?UserName=${userName}`,{headers : this.reqHeader});



  //   // or using HttpParams

  //   // return this.http.get<any[]>(this.url, {
  //   //   params: new HttpParams().set('username', uName)
  //   // });
  // }
 
}
