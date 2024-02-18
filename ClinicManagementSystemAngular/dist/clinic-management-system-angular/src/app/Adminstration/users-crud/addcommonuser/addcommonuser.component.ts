import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { commonUser } from '../../../Shared/Common/commonUser.model';
import { SharedService } from '../../../Shared/Common/shared.service';
import { environment } from '../../../../environments/environment';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-addcommonuser',
  templateUrl: './addcommonuser.component.html',
  styleUrls: ['./addcommonuser.component.css']
})
export class AddCommonUserComponent implements OnInit {


  constructor(private sharedService: SharedService, private toaster: ToastrService,public fb: FormBuilder) { }
  ngOnInit(): void {
  }
  characterPattern = "^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]+[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z-_ ]*$";
  phonePattern = "^01[0-2||5]{1}[0-9]{8}";
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";

  form: FormGroup = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.minLength(5),
      Validators.maxLength(16),
      Validators.pattern(this.characterPattern)
    ]),
    username: new FormControl('', [
      Validators.required,
      Validators.minLength(7),
      Validators.maxLength(16)
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(50)
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.minLength(10),
      Validators.maxLength(50),
      Validators.pattern(this.emailPattern)
    ]),
    phone: new FormControl('', [
      Validators.required,
      Validators.pattern(this.phonePattern)

    ]),
    photo: new FormControl('', Validators.required)
  });

  // form = this.fb.group({
  //   name: new FormControl('', [
  //     Validators.required,
  //     Validators.minLength(5),
  //     Validators.maxLength(16),
  //     Validators.pattern(this.characterPattern)
  //   ]),
  //   username: new FormControl('', [
  //     Validators.required,
  //     Validators.minLength(7),
  //     Validators.maxLength(16)
  //   ]),
  //   password: new FormControl('', [
  //     Validators.required,
  //     Validators.minLength(6),
  //     Validators.maxLength(50)
  //   ]),
  //   email: new FormControl('', [
  //     Validators.required,
  //     Validators.minLength(10),
  //     Validators.maxLength(50),
  //     Validators.pattern(this.emailPattern)
  //   ]),
  //   phone: new FormControl('', [
  //     Validators.required,
  //     Validators.pattern(this.phonePattern)

  //   ]),
  //   photo: new FormControl('', Validators.required)
  // });
  // get name() {
  //   return this.form.get('name')
  // }
  // get username() {
  //   return this.form.get('username')
  // }
  // get password() {
  //   return this.form.get('password')
  // }
  
  url = environment.apiURL
  userData : commonUser = new commonUser;

  files = [];
  onFileChange(event: any) {
    this.files = event.target.files;
    setTimeout(() => {
      this.upload()
    }, 150);

  }

  upload() {
    var formData: FormData = new FormData();
    for (var j = 0; j < this.files.length; j++) {
      formData.append(this.files[j]['name'], this.files[j]);
      //formData.append("file", this.files[j], this.files[j]['name']);
      this.sharedService.upload(formData).subscribe(
        (res: any) => {
          this.userData.photo = res.data[0].path;
        }
      )
    }
  }


  OnAdd() {
    this.userData.id = 0;
    this.sharedService.AddUser(this.userData).subscribe(
      (data: any) => {
        this.userData = data
        if(data.successed){
        this.toaster.success('Added Successfully', 'Clinic Management System')
        }
      }
    )
  }


}
