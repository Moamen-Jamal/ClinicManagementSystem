import { Inject, Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { DOCUMENT } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class RegionService {
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
  // GetAllRegiones(){
  //   return this.http.get(environment.apiURL+`Region/Get`,{headers : this.reqHeader});
  // }
  // GetRegionDetails(id :number){
  //   return this.http.get(environment.apiURL+"Region/Get/"+id,{headers : this.reqHeader})
  // }
  // DeleteRegion(id :number){
  //   return this.http.delete(environment.apiURL+"Region/Delete/"+id,{headers : this.reqHeader})
  // }
  // AddRegion(data :any){
  //   return this.http.post(environment.apiURL+"Region/Post" , data,{headers : this.reqHeader})
  // }
  // UpdateRegion(Id: any,Data: any){
  //   return this.http.put(environment.apiURL+"Region/Put/"+Id , Data,{headers : this.reqHeader})
  // }

  private setHeadersWithImage(): HttpHeaders {
		let headersConfig = {
			'Accept': 'application/json',
			// 'Content-Type' : 'multipart/form-data'
		};
		return new HttpHeaders(headersConfig);
  }
  
  // upload( body: Object) {
	// 	return this.http.post(`${environment.apiURL}File/Upload`, body, { headers: this.setHeadersWithImage() });
	// }
}
