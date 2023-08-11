import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigService } from 'src/app/config.service';
import { EmployeeCardViewDto } from 'src/app/domain/dto/employeeCardViewDto';
import { EmployeeTableViewDto } from 'src/app/domain/dto/employeeTableViewDto';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  controller: string = "employee"
  headerDict :  { [name: string]: string | string[]} = {
    'Content-Type': 'application/json',
    'Access-Control-Allow-Headers': 'Content-Type',
  };
  constructor(private httpClient: HttpClient, private configService: ConfigService) { }

  getAllEmloyees(query: any): Observable<EmployeeTableViewDto[]> {
    return this.httpClient.get<EmployeeTableViewDto[]>(this.configService.baseUrl + this.controller + "/GetAll");
  }

  getById(query: number): Observable<EmployeeCardViewDto> {
    return this.httpClient.get<EmployeeCardViewDto>(this.configService.baseUrl + this.controller + "/GetById/" + query);
  }

  update(command: EmployeeCardViewDto ) {
    return this.httpClient.put(this.configService.baseUrl + this.controller + "/Update/", command, { headers: this.headerDict});
  }

  add(command: EmployeeCardViewDto ) {
    return this.httpClient.post(this.configService.baseUrl + this.controller + "/Add/", command, { headers: this.headerDict});
  }

  delete(employeeId: number) {
    return this.httpClient.delete(this.configService.baseUrl + this.controller + `/Delete/${employeeId}`);
  }
}
