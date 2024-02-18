import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Doctor } from '../../../Shared/Doctor/Doctor.model';
import { DoctorService } from '../../../Shared/Doctor/Doctor.service';
import { environment } from '../../../../environments/environment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-doctordetails',
  templateUrl: './doctordetails.component.html',
  styleUrls: ['./doctordetails.component.css']
})
export class DoctordetailsComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private service: DoctorService
    , private toaster: ToastrService) { }
    url = environment.apiURL
  Data: Doctor = new Doctor;
  ngOnInit(): void {
    this.getByID()
  }
  getByID() {
    // this.service.GetDoctorDetails(this.data.Id).subscribe(
    //   (data: any) => {
    //     this.Data = data.Data
    //   },
    // )
  }

  OnDelete() {
    if (confirm('Are you sure to delete this Doctor?')) {
      // this.service.DeleteDoctor(this.data.ID).subscribe(
      //   (data: any) => {
      //     if(data.Successed){
      //       this.toaster.error('Deleted Successfully', 'Sofra')
      //     }
      //   },
      // )
    }
  }
}
