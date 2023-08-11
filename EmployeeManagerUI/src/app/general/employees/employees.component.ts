import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeCardComponent } from './employee-card/employee-card.component';
import { State } from 'src/app/domain/enum/state.enum';
import { employeeTableViewDto } from 'src/app/domain/dto/employeeTableViewDto';
import { DeleteInfoComponent } from 'src/app/components/delete-info/delete-info.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  employeesData: employeeTableViewDto[] = [];
  filteredEmployeesData: employeeTableViewDto[] = [];
  dataSource: employeeTableViewDto[] = [];

  filterProps = {
    fullName:"",
    salary: "",
    department:"",
    dateOfBirth: "",
    dateOfEmployment:""
  }

  sortProps = {
    fullName: 0,
    salary: 0,
    department: 0,
    dateOfBirth: 0,
    dateOfEmployment: 0
  }
  constructor(private employeeService: EmployeeService, private modalService: NgbModal) { }

  ngOnInit() {
    this.load();
  }

  onEditClick(row: employeeTableViewDto) {
    const modalRef = this.modalService.open(EmployeeCardComponent)
    modalRef.componentInstance.state = State.Edit;
    modalRef.componentInstance.employeeId = row.id;
    modalRef.closed.subscribe(x => {
      if(!x) return;

      this.load();
    });
  }

  onAddClick(row: employeeTableViewDto) {
    const modalRef = this.modalService.open(EmployeeCardComponent);
    modalRef.componentInstance.state = State.Add;
    modalRef.componentInstance.employeeId = row.id;
    modalRef.closed.subscribe(x => {
      if(!x) return;

      this.load();
    });
  }

  onDeleteClick(row: employeeTableViewDto){
    this.modalService.open(DeleteInfoComponent).closed.subscribe(x => {
      if(!x) return;      
      this.employeeService.delete(row.id).subscribe(x => {
        this.load();
      });
    });
  }

  load() {
    this.employeeService.getAllEmloyees({}).subscribe(x => {
      if(!x) return;
      this.dataSource = x;
      this.employeesData = x.slice();
      
    })
  }

  clearSortsAndFilters() {
    Object.keys(this.filterProps).forEach(x => this.sortProps[x] = "")
    Object.keys(this.sortProps).forEach(x => this.sortProps[x] = 0)
  }

  filter(remFilter:boolean= false) {
    if(remFilter) {
      Object.keys(this.filterProps).forEach(prop => {
        this.filterProps[prop] = "";
      });
      this.dataSource = this.employeesData;
    }
    let condition = "";
    Object.keys(this.filterProps).forEach(prop => {
      if(this.filterProps[prop]) {
        if(condition != "") condition += " && "
        if(this.filterProps[prop] instanceof Date && !isNaN(this.filterProps[prop])) {
          condition += `new Date(x['${prop}']).toLocaleDateString("en-US") == new Date(this.filterProps['${prop}']).toLocaleDateString("en-US")`;
          return;
        }
        condition += `x['${prop}'].toString().includes(this.filterProps['${prop}'].toString())`
      }
    });
    if(condition != "") {
      //var finalCondition=condition.substring(2, condition.length);
      this.dataSource = this.employeesData.filter(x => eval(condition));

      return;
    }
    
    this.dataSource = this.employeesData;

  }

  sort(propName) {
    
    if(typeof(this.sortProps[propName]) != "number") return;
    this.sortProps[propName] == 2 ?  this.sortProps[propName] = 0 :this.sortProps[propName]++;
    console.log(this.sortProps[propName]);
    switch(this.sortProps[propName]) {
      case 0 : {        
        this.dataSource = this.employeesData.slice();
        break;
      }
      case 1 : {
        this.dataSource = this.dataSource.sort(( a, b ) => {
          if(typeof(a[propName]) == "number" ) 
          return a[propName] - b[propName]
          if(typeof(a[propName]) == "string" ) 
          return a[propName].localeCompare(b[propName]);

           return 0;
        })
        break;
      }
      case 2 : {
        this.dataSource = this.dataSource.sort(( a, b ) => {
          if (b[propName] < a[propName]) {            
            return -1;
            }
            if (b[propName] > a[propName]) {
            return 1;
            }
            return 0;
            });
        break;
      }
    }
    
  }

}
