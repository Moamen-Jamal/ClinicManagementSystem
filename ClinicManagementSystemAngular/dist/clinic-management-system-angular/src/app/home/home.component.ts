import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog ,MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { FormBuilder ,FormControl, Validators } from '@angular/forms';
import { commonUser } from '../Shared/Common/commonUser.model';
import { SharedService } from '../Shared/Common/shared.service';
import { Doctor } from '../Shared/Doctor/Doctor.model';
import { DoctorService } from '../Shared/Doctor/Doctor.service';
import { GovernateService } from '../Shared/Governate/governate.service';
import { UserService } from '../Shared/User/user.service';
import { CityService } from '../Shared/City/city.service';
import { City } from '../Shared/City/city.model';
import { Governate } from '../Shared/Governate/governate.model';
import { User } from '../Shared/User/user.model';
import { PrivacypolicyComponent } from '../Adminstration/privacypolicy/privacypolicy/privacypolicy.component';
import { DOCUMENT } from '@angular/common';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
  //HomeComponent
export class HomeComponent implements OnInit {
  localStorage: any;
  sessionStorage: any;
  constructor(@Inject(DOCUMENT) private document: Document, private dialog :MatDialog ,
  private doctorservice :DoctorService ,private router :Router , private cityService :CityService,
  private governateService : GovernateService ,  public fb: FormBuilder,
  private userService :UserService , private service :SharedService) { 
    this.localStorage = document.defaultView?.localStorage;
    this.sessionStorage = document.defaultView?.sessionStorage;
  }
 //ngOnInit
  ngOnInit(): void {
    this.getDoctor()
    this.getGovernate()
    this.getCity()
    //this.getUser()
    this.getPatient()
    this.Notuser = this.localStorage?.getItem('userToken')
  }
  Notuser: any;
  form =  this.fb.group({
    search1: new FormControl('',Validators.required),
    search2: new FormControl('',Validators.required)
  });

    get search2(){
    return this.form.get('search2')
     };
  
    get search1(){
      return this.form.get('search1')
    };
  doctor:Doctor = new Doctor;
  patient :commonUser = new commonUser; 
  CityList : City[] = [];
  GovernateList : Governate [] = [];
  currCityID : any;
  currGovID: any ;
  currCityList :City[] = [];
  user : User = new User;
  getUser(){
    if(this.localStorage?.getItem('userToken')!= null){
      const userID = this.localStorage?.getItem('userID');
      this.userService.getUser(parseInt(userID?? '0')).subscribe(
      (data :any)=>{
        this.user = data.data
      }
    )
    }
  }
Search(){
  this.localStorage?.setItem('CityID',this.currCityID)
  if(this.localStorage?.getItem('userToken')== null){
    this.router.navigate(['/MasterDoctor/PubDoctors'])
  }else{
    if(this.user.Role== "Doctor"){
      this.router.navigate(['/MasterDoctor/Doctors'])
     }
     else{
      this.router.navigate(['/MasterDoctor/PubDoctors'])
    }
  }
  
 

}
  getCity(){
    // this.cityService.GetAllCityes().subscribe(
    //   (data :any)=>{this.CityList = data.Data} 
    // )
    this.CityList = this.cityService.GetAllCityes();
  }
  getGovernate(){
    // this.governateService.GetAllGovernatees().subscribe(
    //   (data :any)=>{this.GovernateList = data.Data} 
    // )

    this.GovernateList = this.governateService.GetAllGovernatees();
  }
  
  getGovID(e: any): void {
  
    this.currGovID = e
    if(e >0){
      this.currCityList = this.CityList.filter(i=>i.governateID == this.currGovID)
    } 
  }

  getCityID(e: any): void {
  this.currCityID = e
  }
 

  getDoctor(){
    if(this.localStorage?.getItem('userToken')!= null){
      const userID = this.localStorage?.getItem('userID');
    //   this.doctorservice.GetDoctorDetails(parseInt(userID?? '0')).subscribe(
    //   (data:any)=>{
    //     this.doctor = data.data;
    //   }
    // )
  }
  }
  getPatient(){
    if(this.localStorage?.getItem('userToken')!= null){
      const userID = this.localStorage?.getItem('userID');
      this.service.GetUserDetails(parseInt(userID?? '0')).subscribe(
      (data:any)=>{
        this.patient = data.data;
      }
    )}
  }



  LogOut(){
    this.localStorage?.removeItem('userToken');
    this.localStorage?.removeItem('userID');
    this.localStorage?.removeItem('userRole');
    this.localStorage?.removeItem('userName');
    this.sessionStorage?.removeItem('isUser');
    this.router.navigate(['/Login']);
    
  }
  
  
  Login(){
    this.localStorage?.removeItem('userToken');
    this.localStorage?.removeItem('userID');
    this.sessionStorage?.removeItem('isUser')
    this.router.navigate(['/Login']);
  }
  
  tosearch()
  {
    const search = document.getElementById("search");
    if(search)
      search.scrollIntoView({behavior:"smooth"});
  }
  toabout()
  {
    const about = document.getElementById("about");
    if(about)
      about.scrollIntoView({behavior:"smooth"});
  }
  tomenu()
  {
    const menu = document.getElementById("menu");
    if(menu)
      menu.scrollIntoView({behavior:"smooth"});
  }
  privacypolicy() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "90%";
    this.dialog.open(PrivacypolicyComponent, dialogConfig);
  }
}
