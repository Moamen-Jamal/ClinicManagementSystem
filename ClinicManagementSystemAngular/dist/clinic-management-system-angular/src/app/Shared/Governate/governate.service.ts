import { Inject, Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { DOCUMENT } from '@angular/common';
import { Governate } from './governate.model';

@Injectable({
  providedIn: 'root'
})
export class GovernateService {
  localStorage: any;
  reqHeader: any;
  userRole: any;


  constructor(@Inject(DOCUMENT) private document: Document,private http :HttpClient) { 
    this.localStorage = document.defaultView?.localStorage;
    this.reqHeader = new HttpHeaders(
      {
        'Content-Type' : 'application/json; charset=utf-8',
        'Accept'       : 'application/json', 
        //'Authorization' :'Bearer ' + this.localStorage?.getItem("userToken")
      });
      this.userRole = this.localStorage?.getItem('userRole');
  }
  GetAllGovernatees(){
     let Governates:Governate[] = [];
     Governates[0] = {id:1, name: 'Cairo'}
    return Governates;
  //   let pageIndex =0;
  //   let pageSize = 6;
  //   return this.http.get(environment.apiURL+`Employee`+`/Get?pageIndex=${pageIndex}&pageSize=${pageSize}`,{headers : this.reqHeader});
  }
  // GetGovernateDetails(id :number){
  //   return this.http.get(environment.apiURL+"Governate/Get/"+id,{headers : this.reqHeader})
  // }
  // DeleteGovernate(id :number){
  //   return this.http.delete(environment.apiURL+"Governate/Delete/"+id,{headers : this.reqHeader})
  // }
  // AddGovernate(data :any){
  //   return this.http.post(environment.apiURL+"Governate/Post" , data,{headers : this.reqHeader})
  // }
  // UpdateGovernate(ID: any,Data: any){
  //   return this.http.put(environment.apiURL+"Governate/Put/"+ID , Data,{headers : this.reqHeader})
  // }

  private setHeadersWithImage(): HttpHeaders {
		let headersConfig = {
			'Accept': 'application/json',
			// 'Content-Type' : 'multipart/form-data'
		};
		return new HttpHeaders(headersConfig);
  }
  
  upload( body: Object) {
		//return this.http.post(`${environment.apiURL}File/Upload`, body, { headers: this.setHeadersWithImage() });
	}
}
