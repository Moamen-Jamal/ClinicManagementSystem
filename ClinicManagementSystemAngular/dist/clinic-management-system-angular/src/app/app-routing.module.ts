import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MastercommonuserComponent } from './MasterModules/commonuser/mastercommonuser/mastercommonuser.component';
import { AuthenticationGuard } from './Guards/authentication.guard';
import { MasterComponent } from './Adminstration/master/master.component';
import { DoctorCrudComponent } from './Adminstration/doctor-crud/doctor-crud.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { ForbiddenComponent } from './forbidden/forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { ListingComponent } from './Adminstration/users-crud/listing.component';

const routes: Routes = [
  {path:'BackOffice' ,component: MastercommonuserComponent, canActivate:[AuthenticationGuard] ,
    data: { permittedRoles: ['Admin','Employee'] },
    children:[
    {path:'' , component : MasterComponent, canActivate:[AuthenticationGuard] , data: { permittedRoles: ['Admin','Employee'] },},
    {path:'BackOfficeHome' ,component:MasterComponent , canActivate:[AuthenticationGuard], data: { permittedRoles: ['Admin'] },},
    {path:'Employee/EmployeeCrud' ,component: ListingComponent , canActivate:[AuthenticationGuard], data: { permittedRoles: ['Employee'] },} ,
    {path:'Patient/PatientCrud' ,component: ListingComponent , canActivate:[AuthenticationGuard], data: { permittedRoles: ['Employee'] },} ,
    {path:'Doctor/DoctorCrud' ,component: DoctorCrudComponent, canActivate:[AuthenticationGuard] , data: { permittedRoles: ['Employee'] },}
    ] } ,
  { path: 'Login', component: SignInComponent },
  { path: 'forbidden', component: ForbiddenComponent },
//   { path: 'ٌRegister', component: RegisterComponent },
//   { path: 'ٌCustRegister', component: CustRegisterComponent },
  { path: 'forbidden', component: ForbiddenComponent },

  { path: '', redirectTo: 'Home', pathMatch: 'full' },

  { path: 'Home', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
