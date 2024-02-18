import { Component, OnInit, Inject, Output } from '@angular/core';
import { MatDialog, MatDialogConfig, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UpdatecommonuserComponent } from '../../updatecommonuser/updatecommonuser.component';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../../environments/environment';
import { SharedService } from '../../../../Shared/Common/shared.service';
import { commonUser } from '../../../../Shared/Common/commonUser.model';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-commonuser-details',
  templateUrl: './commonuser-details.component.html',
  styleUrls: ['./commonuser-details.component.css']
})
export class CommonUserDetailsComponent implements OnInit {
  localStorage: any;
  constructor(@Inject(DOCUMENT) private document: Document,@Inject(MAT_DIALOG_DATA) public data: any,
    private service: SharedService, private dialog: MatDialog, private router: Router
    , private toaster: ToastrService) {
      this.localStorage = document.defaultView?.localStorage;
     }

  Data: commonUser = new commonUser;
  url = environment.apiURL
  ngOnInit(): void {
    this.GetDetails();
  }
  GetDetails() {
    this.service.GetUserDetails(this.data.id).subscribe(
      (data: any) => {
        this.Data = data.data;
      }
    )
  }

  OnDelete() {
    if (confirm('Are you sure to delete this User?')) {
      if (this.localStorage?.getItem('userID') == this.data.id) {
        this.service.DeleteUser(this.data.id).subscribe(
          (data: any) => {

            if (data.successed) {
              this.localStorage?.removeItem('userToken')
              this.router.navigate(['/Login'])
            }

          }
        )
      } else {
        this.service.DeleteUser(this.data.id).subscribe(
          (data: any) => {
            if (data.successed) {
              this.toaster.error('Deleted Successfully', 'Clinic Management System')
            }
          }
        )
      }
    }
  }

  updateUser(id: any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "42%";
    dialogConfig.height = "90%";
    dialogConfig.position = {
      top: '50px'
    }

    dialogConfig.data = { id }
    this.dialog.open(UpdatecommonuserComponent, dialogConfig).afterClosed().subscribe(res => {
      setTimeout(() => {
        this.ngOnInit()
      }, 250);
    });
  }
}
