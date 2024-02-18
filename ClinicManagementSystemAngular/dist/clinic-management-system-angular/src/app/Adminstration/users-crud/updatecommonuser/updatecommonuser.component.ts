import { Component, OnInit, Inject, Input } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { commonUser } from '../../../Shared/Common/commonUser.model';
import { SharedService } from '../../../Shared/Common/shared.service';

@Component({
  selector: 'app-updatecommonuser',
  templateUrl: './updatecommonuser.component.html',
  styleUrls: ['./updatecommonuser.component.css']
})
export class UpdatecommonuserComponent implements OnInit {
  url = environment.apiURL
  constructor(@Inject(MAT_DIALOG_DATA) public user: any,
    private service: SharedService, private toaster: ToastrService) { }

  files = [];
  ErrorMessage = "";
  ngOnInit(): void {
    this.getUser()
    setTimeout(() => {
      this.upload()
    }, 150);
  }
  oldData: commonUser = new commonUser;
  getUser() {
    this.service.GetUserDetails(this.user.id).subscribe(
      (res: any) => {
        this.oldData = res.data;
      }
    )
  }

  OnUpdate() {

    this.service.UpdateUser(this.oldData).subscribe(
      (data: any) => {
        if(data.successed){
        this.toaster.success('Updated Successfully', 'Clinic Management System')
        }
      }
    )
  }

  onFileChange(event: any) {
    this.files = event.target.files;
    setTimeout(() => {
      this.upload()
    }, 200);
  }
  upload() {
    let formData: FormData = new FormData();
    for (var j = 0; j < this.files.length; j++) {
      formData.append("file[]", this.files[j], this.files[j]['name']);
      this.service.upload(formData).subscribe(
        (res: any) => {
          this.oldData.photo = res.data[0].path;
        }
      )
    }
  }


}
