import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgbDateAdapter, NgbDatepickerModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EmployeesComponent } from './employees.component';
import { EmployeeCardComponent } from './employee-card/employee-card.component';
import { NgxBootstrapIconsModule } from 'ngx-bootstrap-icons';
import { FormsModule } from '@angular/forms';
import { CustomAdapter } from 'src/app/datepicker-adapter';

@NgModule({
  declarations: [
    EmployeesComponent,
    EmployeeCardComponent
   ],
   exports:[
    EmployeesComponent,
    EmployeeCardComponent
   ],
  imports: [
    FormsModule,
    BrowserModule,
    HttpClientModule,
    NgbModule,
    NgbDatepickerModule,
    NgxBootstrapIconsModule,
  ],
  
  providers: [
    { provide: NgbDateAdapter, useClass: CustomAdapter },
  ]
})
export class EmployeesModule { }
