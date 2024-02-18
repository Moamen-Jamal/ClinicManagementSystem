import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../Shared/Common/shared.service';
import { DashBoard } from '../../Shared/Common/DashBoard.model';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.css']
})
export class MasterComponent implements OnInit {

  constructor(private service :SharedService) { }
  EmployeeDashBoard: DashBoard = new DashBoard;
  ngOnInit(): void {
    this.getEmployeeDashboard()
  }
  getEmployeeDashboard(){
    this.service.GetEmployeeDashboard().subscribe(
      (res :any)=>{
        this.EmployeeDashBoard = res.data      
      }
    )
  }

}
