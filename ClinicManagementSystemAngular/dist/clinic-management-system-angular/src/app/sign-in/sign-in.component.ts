import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { UserService } from '../Shared/User/user.service';
import { DOCUMENT } from '@angular/common'




@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
})


export class SignInComponent implements OnInit {
  isLoginError: boolean = false;
  ErrorMessage: string = "";
  localStorage: any;
  sessionStorage: any;
  constructor(@Inject(DOCUMENT) private document: Document, private userService: UserService, private router: Router ,public fb: FormBuilder ) { 
     this.localStorage = document.defaultView?.localStorage;
     this.sessionStorage = document.defaultView?.sessionStorage;
  }
 
  ngOnInit(): void {
  }
  //  payLoad = JSON.parse(window.atob(localStorage.getItem('userToken').split('.')[1]));
  //  userRole = this.payLoad.Roles;
  OnSubmit(userName: any, password: any) {
    this.userService.UserAuthentication(userName, password).subscribe((res: any) => {
      if (res.successed == true) {
        this.localStorage?.setItem('userToken', res.data.token);
        this.localStorage?.setItem('userID', res.data.id);
        this.localStorage?.setItem('userName', res.data.userName);
        this.localStorage?.setItem('userRole', res.data.role);
        if (res.data.role == "Doctor"){
          this.router.navigate(['/MasterPortal/DoctorProfile']);
        }
        else if (res.data.role == "Patient"){
          if(this.sessionStorage.getItem('isUser')!= null){
            this.router.navigate(['/MasterPortal/Appointment'])
          }
          else{ this.router.navigate(['/Home'])}
       
        }
        else if (res.data.role == "Admin"){
          this.router.navigate(['/BackOffice']);
        }
        else if (res.data.role == "Employee"){
          this.router.navigate(['/BackOffice']);
        }
        
      } else {
        this.ErrorMessage = res.message;
        this.isLoginError = true;
      }
    },
      (error) => {
        this.ErrorMessage = "حدث خطأ ما";
        this.isLoginError = true;
      });

  }

  /////////////////////////////
  
  form =  this.fb.group({
    UserN: new FormControl('',   Validators.required),
    pass: new FormControl('',Validators.required)
 });
 get UserN(){
  return this.form.get('UserN')
}
get pass(){
  return this.form.get('UserN')
}
  
  

}
