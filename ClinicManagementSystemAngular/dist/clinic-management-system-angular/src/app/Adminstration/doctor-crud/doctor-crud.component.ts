import { Component, OnInit } from '@angular/core';
import { MatDialog ,MatDialogConfig } from '@angular/material/dialog';
import { DoctorService } from '../../Shared/Doctor/Doctor.service';
import { Doctor } from '../../Shared/Doctor/Doctor.model';
import { environment } from '../../../environments/environment';
import { DoctordetailsComponent } from './doctordetails/doctordetails.component';
@Component({
  selector: 'app-doctor-crud',
  templateUrl: './doctor-crud.component.html',
  styleUrls: ['./doctor-crud.component.css']
})
export class DoctorCrudComponent implements OnInit {

  constructor(private dialog :MatDialog , private service :DoctorService) { }
    options={ itemsPerPage:6, currentPage:1, id :'pagination', totalItems:200 }
    DataList :Doctor[] = [];
    url = environment.apiURL
  ErrorMessage :string = "";
  ngOnInit(): void {
    this.getAll(this.options.currentPage,6)
    
  }
  getAll(pageIndex: any,pageSize: any){
    // this.service.GetAllDoctors(pageIndex,pageSize).subscribe(
    //   (data:any)=>{
    //     this.options.totalItems=data.Data.Records;
    //     this.DataList = data.Data.Result
    //   },
    // )
  }
  
   
  getNextPrevData(pageIndex: any){
    
    this.getAll(pageIndex,6);
    this.options.currentPage= pageIndex;
  }
  doctordetails(Id: any){
    const  dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true ;
    dialogConfig.disableClose = true ;
    dialogConfig.width = "40%";
    dialogConfig.height="87%";
    dialogConfig.position = {
      top : '55px'
    }
    
    dialogConfig.data = {Id}
    this.dialog.open(DoctordetailsComponent ,dialogConfig).afterClosed().subscribe(res => {
      setTimeout(() => {
        this.ngOnInit()
      }, 250);
    });
  }
}
