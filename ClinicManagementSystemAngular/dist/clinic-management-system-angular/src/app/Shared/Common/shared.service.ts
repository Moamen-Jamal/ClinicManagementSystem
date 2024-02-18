import { Inject, Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { DOCUMENT } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  localStorage: any;
  reqHeader: any;
  userRole: any;
  commonRoleCrud: any;

  constructor(@Inject(DOCUMENT) private document: Document, private http :HttpClient) { 
    this.localStorage = document.defaultView?.localStorage;
    this.reqHeader = new HttpHeaders(
      {
        'Content-Type' : 'application/json; charset=utf-8',
        'Accept'       : 'application/json', 
        //'Authorization' :'Bearer ' + this.localStorage?.getItem("userToken")
      });
      this.userRole = this.localStorage?.getItem('userRole');
  }
  GetAllUsers(pageIndex:number,pageSize:number,name="",isDescinding:boolean= false){
    return this.http.get(environment.apiURL+ (this.commonRoleCrud?? this.userRole) + `/Get?pageIndex=${pageIndex}&pageSize=${pageSize}&name=${name}&isDescinding=${isDescinding}`,{headers : this.reqHeader});
  }
  GetUserDetails(id :number){
    return this.http.get(environment.apiURL + (this.commonRoleCrud?? this.userRole) + "/Get/"+id,{headers : this.reqHeader})
  }
  DeleteUser(id :number){
    return this.http.delete(environment.apiURL + (this.commonRoleCrud?? this.userRole)+ "/Delete/"+id,{headers : this.reqHeader})
  }
  AddUser(data :any){
    return this.http.post(environment.apiURL + (this.commonRoleCrud?? this.userRole) + "/Post" , data,{headers : this.reqHeader})
  }
  UpdateUser(Data: any){
    return this.http.put(environment.apiURL + (this.commonRoleCrud?? this.userRole) + "/Put" , Data,{headers : this.reqHeader})
  }
  GetEmployeeDashboard(){
    return this.http.get(environment.apiURL+"Employee/GetDashboardDetails/",{headers : this.reqHeader})
  }

  
  upload( body: Object) {
		return this.http.post(`${environment.apiURL}File/Upload`, body);
	}
}
