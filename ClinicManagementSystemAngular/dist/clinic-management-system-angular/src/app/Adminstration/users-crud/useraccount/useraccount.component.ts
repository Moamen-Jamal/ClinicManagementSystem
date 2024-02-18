import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog ,MatDialogConfig } from '@angular/material/dialog';
import { UpdatecommonuserComponent } from '../updatecommonuser/updatecommonuser.component';
import { environment } from '../../../../environments/environment';
import { commonUser } from '../../../Shared/Common/commonUser.model';
import { SharedService } from '../../../Shared/Common/shared.service';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-useraccount',
  templateUrl: './useraccount.component.html',
  styleUrls: ['./useraccount.component.css']
})
export class UseraccountComponent implements OnInit {
  localStorage: any;
  User : commonUser = new  commonUser();
  constructor(@Inject(DOCUMENT) private document: Document,private dialog :MatDialog , private service :SharedService) {
    this.localStorage = document.defaultView?.localStorage;
   }
  url = environment.apiURL
  ngOnInit(): void {
    this.getUser()
  }
  updateUser(id: any){
    const  dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true ;
    dialogConfig.disableClose = true ;
    dialogConfig.width = "40%";
    dialogConfig.height="90%";
    dialogConfig.position={
      top:'55px'
    }
    dialogConfig.data = {id}
    this.dialog.open(UpdatecommonuserComponent,dialogConfig).afterClosed().subscribe(res => {
      setTimeout(() => {
        this.ngOnInit();
      }, 350);
    });
  }
  getUser(){
    const userID = this.localStorage?.getItem('userID');
    this.service.GetUserDetails(parseInt((userID?? '0'))).subscribe(
      (data:any)=>{
        this.User = data.data;
      }
    )
  }

}
