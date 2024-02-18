import { Inject, Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { DOCUMENT } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  localStorage: any;
  reqHeader: any;

  constructor(@Inject(DOCUMENT) private document: Document,private http :HttpClient) { 
    this.localStorage = document.defaultView?.localStorage;
    this.reqHeader = new HttpHeaders(
      {
        'Content-Type' : 'application/json; charset=utf-8',
        'Accept'       : 'application/json', 
        //'Authorization' :'Bearer ' + this.localStorage?.getItem("userToken")
      });
  }
  GetAllDoctors(pageIndex:number,pageSize:number){
    //return this.http.get(environment.apiURL+`Doctor/Get?pageIndex=${pageIndex}&pageSize=${pageSize}`,{headers : this.reqHeader});
  }
  GetDoctorDetails(id :number){
    //return this.http.get(environment.apiURL+"Doctor/Get/"+id,{headers : this.reqHeader})
  }
  DeleteDoctor(id :number){
    //return this.http.delete(environment.apiURL+"Doctor/Delete/"+id,{headers : this.reqHeader})
  }
  AddDoctor(data :any){
    //return this.http.post(environment.apiURL+"Doctor/Post" , data,{headers : this.reqHeader})
  }
  UpdateDoctor(Id: any,Data: any){
    //return this.http.put(environment.apiURL+"Doctor/Put/"+Id , Data,{headers : this.reqHeader})
  }


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
