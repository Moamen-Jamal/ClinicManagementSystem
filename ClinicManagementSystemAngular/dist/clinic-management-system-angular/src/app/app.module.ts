import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AsideComponent } from './aside/aside.component';
import { DoctorCrudComponent } from './Adminstration/doctor-crud/doctor-crud.component';
import { ListingComponent } from './Adminstration/users-crud/listing.component';
import { MasterComponent } from './Adminstration/master/master.component';
import { UseraccountComponent } from './Adminstration/users-crud/useraccount/useraccount.component';
import { MastercommonuserComponent } from './MasterModules/commonuser/mastercommonuser/mastercommonuser.component';
import { HomeComponent } from './home/home.component';
import { ForbiddenComponent } from './forbidden/forbidden/forbidden.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { AddCommonUserComponent } from './Adminstration/users-crud/addcommonuser/addcommonuser.component';
import { UpdatecommonuserComponent } from './Adminstration/users-crud/updatecommonuser/updatecommonuser.component';
import { DoctordetailsComponent } from './Adminstration/doctor-crud/doctordetails/doctordetails.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule, DatePipe, HashLocationStrategy, LocationStrategy } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient,withFetch  } from '@angular/common/http';
import { UserService } from './Shared/User/user.service';
import { AuthenticationGuard } from './Guards/authentication.guard';
import { ToastrModule } from 'ngx-toastr';
import { NgxPaginationModule } from 'ngx-pagination';
import { MatDialogModule } from '@angular/material/dialog';
import { PrivacypolicyComponent } from './Adminstration/privacypolicy/privacypolicy/privacypolicy.component';
import { CommonUserDetailsComponent } from './Adminstration/users-crud/commonuserdetailspopup/commonuser-details/commonuser-details.component';
import { AuthInterceptor } from './Guards/auth-interceptor';
import { NgxLoadingModule } from 'ngx-loading';


@NgModule({
  declarations: [
    AppComponent,
    AsideComponent,
    DoctorCrudComponent,
    ListingComponent,
    MasterComponent,
    UseraccountComponent,
    ForbiddenComponent,
    MastercommonuserComponent,
    HomeComponent,
    ForbiddenComponent,
    SignInComponent,
    AddCommonUserComponent,
    UpdatecommonuserComponent, 
    DoctordetailsComponent, 
    CommonUserDetailsComponent,
    AddCommonUserComponent, 
    PrivacypolicyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CommonModule, 
    RouterOutlet,
    MatDialogModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    NgxLoadingModule.forRoot({})

  ],
  // entryComponents: [UpdatecommonuserComponent, DoctordetailsComponent, CommonUserDetailsComponent, AddCommonUserComponent, 
  //   PrivacypolicyComponent],
  providers: [
    provideClientHydration(),
    UserService,
    AuthenticationGuard,
    provideHttpClient(withFetch()),
    DatePipe,
    {provide : LocationStrategy , useClass :HashLocationStrategy},
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],


  bootstrap: [AppComponent],
   exports: [
    
  //   UniqueEmailValidatorDirective,
  //   UniqueUsernameValidatorDirective
  ]
})
export class AppModule { }

// @NgModule({
//   declarations: [
//     AppComponent
//   ],
//   imports: [
//     BrowserModule,
//     AppRoutingModule
//   ],
//   providers: [
//     provideClientHydration()
//   ],
//   bootstrap: [AppComponent]
// })
// export class AppModule { }
