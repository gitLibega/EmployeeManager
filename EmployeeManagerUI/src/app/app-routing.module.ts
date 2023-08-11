import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './general/about-us/about-us.component';
import { EmployeesComponent } from './general/employees/employees.component';

const routes: Routes = [
  { path: "", redirectTo:"/about", pathMatch:'full' },
  { path: "about", component: AboutUsComponent },
  { path: "employees",  component: EmployeesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
