import { Inject, Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { DOCUMENT } from '@angular/common';
import { City } from './city.model';

@Injectable({
  providedIn: 'root'
})
export class CityService {
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
  GetAllCityes(){
    let Cities:City[] = [];
    Cities[0] = {id:1, name: 'Maadi',governateID:1}
   return Cities;
  }
  // GetCityDetails(id :number){
  //   return this.http.get(environment.apiURL+"City/Get/"+id,{headers : this.reqHeader})
  // }
  // DeleteCity(id :number){
  //   return this.http.delete(environment.apiURL+"City/Delete/"+id,{headers : this.reqHeader})
  // }
  // AddCity(data :any){
  //   return this.http.post(environment.apiURL+"City/Post" , data,{headers : this.reqHeader})
  // }
  // UpdateCity(ID: any,Data: any){
  //   return this.http.put(environment.apiURL+"City/Put/"+ID , Data,{headers : this.reqHeader})
  // }

  private setHeadersWithImage(): HttpHeaders {
		let headersConfig = {
			'Accept': 'application/json',
			// 'Content-Type' : 'multipart/form-data'
		};
		return new HttpHeaders(headersConfig);
  }
  
  upload( body: Object) {
		return this.http.post(`${environment.apiURL}File/Upload`, body, { headers: this.setHeadersWithImage() });
	}
}
