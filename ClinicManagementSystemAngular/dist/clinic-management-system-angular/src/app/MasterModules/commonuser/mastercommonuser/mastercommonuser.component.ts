import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog ,MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { environment } from '../../../../environments/environment';
import { PrivacypolicyComponent } from '../../../Adminstration/privacypolicy/privacypolicy/privacypolicy.component';
import { commonUser } from '../../../Shared/Common/commonUser.model';
import { SharedService } from '../../../Shared/Common/shared.service';
import { UseraccountComponent } from '../../../Adminstration/users-crud/useraccount/useraccount.component';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-mastercommonuser',
  templateUrl: './mastercommonuser.component.html',
  styleUrls: ['./mastercommonuser.component.css']
})
export class MastercommonuserComponent implements OnInit {
  url = environment.apiURL;
  localStorage: any;
  sessionStorage: any;
  User: commonUser = new commonUser;

  constructor(@Inject(DOCUMENT) private document: Document, private dialog :MatDialog , private router :Router ,public service :SharedService ) { 
    this.localStorage = document.defaultView?.localStorage;
    this.sessionStorage = document.defaultView?.sessionStorage;
  }
  
  ngOnInit(): void {
  
      this.getUser()
    
    
  }
  
  getUser(){
    const userID = this.localStorage?.getItem('userID');
    this.service.GetUserDetails(parseInt(userID?? '0')).subscribe(
      (data:any)=>{
        this.User = data.data;
      }
    )
  }
  
  Login(){
    this.localStorage?.removeItem('userToken');
    this.localStorage?.removeItem('userID');
    this.sessionStorage?.removeItem('isUser')
    this.router.navigate(['/Login']);
  }
  
  
  LogOut(){
    this.localStorage?.removeItem('userToken');
    this.localStorage?.removeItem('userID');
    this.localStorage?.removeItem('userRole');
    this.localStorage?.removeItem('userName');
    this.sessionStorage?.removeItem('isUser');
    this.router.navigate(['/Home']);
  }
  privacypolicy(){
    const  dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true ;
    dialogConfig.disableClose = true ;
    dialogConfig.width = "50%";
    dialogConfig.height="90%";
    this.dialog.open(PrivacypolicyComponent ,dialogConfig);
  }

  commonUserAccount(){
    const  dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true ;
    dialogConfig.disableClose = true ;
    dialogConfig.width = "40%";
    dialogConfig.height="85%";
    dialogConfig.position={
      top: '60px'
    }
    
    this.dialog.open(UseraccountComponent ,dialogConfig).afterClosed().subscribe(res => {
      this.getUser();
    });
  }
}
