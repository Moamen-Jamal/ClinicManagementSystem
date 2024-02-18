import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AddCommonUserComponent } from './addcommonuser/addcommonuser.component';
import { SharedService } from '../../Shared/Common/shared.service';
import { commonUser } from '../../Shared/Common/commonUser.model';
import { CommonUserDetailsComponent } from './commonuserdetailspopup/commonuser-details/commonuser-details.component';
import { environment } from '../../../environments/environment';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.css']
})
export class ListingComponent implements OnInit {

  constructor(private dialog: MatDialog, private service: SharedService,private toaster: ToastrService) { }
  DataList: commonUser[] = [];

  options = { itemsPerPage: 3, currentPage: 1, id: 'pagination', totalItems: 500 }
  url = environment.apiURL
  ErrorMessage: string = "";
  nameSearch: string = "";
  isLoading : boolean = false;
  isDescending: boolean =false;
  ngOnInit(): void {
    this.getAll(this.options.currentPage, 3)
  }
  getAll(pageIndex: number, pageSize: number) {
    this.isLoading = true;
    this.service.GetAllUsers(pageIndex, pageSize,this.nameSearch.trim(),this.isDescending).subscribe({
      next: (res: any) => {
        this.isLoading = false;
        if(res.successed){
          this.options.totalItems = res.data.records;
          this.DataList = res.data.result
        }
      },
      error: () =>{
        this.isLoading = false;
      },
      complete: ()=>{
        this.isLoading = false;
      }
    })
  }
  getNextPrevData(pageIndex: number) {

    this.getAll(pageIndex, 3);
    this.options.currentPage = pageIndex;
  }
  userDetails(id: any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "40%";
    dialogConfig.height = "85%";
    dialogConfig.position = {
      top : '55px'
    }

    dialogConfig.data = { id }
    this.dialog.open(CommonUserDetailsComponent, dialogConfig).afterClosed().subscribe(res => {
      // setTimeout(() => {
      //   this.getAll(this.options.currentPage, 6)
      // }, 200);
      this.getAll(this.options.currentPage, 3);
    });
  }
  add() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "40%";
    dialogConfig.height = "91%";
    dialogConfig.position = {
      top: '55px'
    }
    this.dialog.open(AddCommonUserComponent, dialogConfig).afterClosed().subscribe(res => {
      // setTimeout(() => {
      //   this.getAll(this.options.currentPage, 6)
      // }, 200);
      this.getAll(this.options.currentPage, 3);
    });
  }

  filteringData(isDesc:boolean = false){
    this.isDescending = isDesc;
    if(this.nameSearch.trim() || isDesc){
      this.isLoading = true;
      const pageIndex = 1;
      const pageSize = 3;
      this.service.GetAllUsers(pageIndex,pageSize,this.nameSearch,isDesc).subscribe(
        (res: any) => {
          this.isLoading = false;
          debugger;
          if(res.data && res.data?.result && res.data?.result?.length > 0){
            this.options.totalItems = res.data.records;
            this.options.currentPage = 1;
            this.options.itemsPerPage = 3;
            this.DataList = res.data.result;
          }
          else{
            this.toaster.warning("No Data Found");
          }
          
        },(error) =>{
          this.isLoading = false;
        }
      )
    }
    else{
      this.getAll(this.options.currentPage, 3);
    }
  }
}
