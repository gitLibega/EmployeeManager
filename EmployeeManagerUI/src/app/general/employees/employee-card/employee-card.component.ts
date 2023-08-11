import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { NgbActiveModal, NgbCalendar, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { employeeCardViewDto } from 'src/app/domain/dto/employeeCardViewDto';
import { State } from 'src/app/domain/enum/state.enum';
import { EmployeeService } from '../employee.service';
import { CustomAdapter } from 'src/app/datepicker-adapter';
@Component({
  selector: 'app-employee-card',
  templateUrl: './employee-card.component.html',
  styleUrls: ['./employee-card.component.css'],
})
export class EmployeeCardComponent implements OnInit {
  @Input() employeeId: number = 0;
  @Input() state: State = State.Add;

  model: employeeCardViewDto = new employeeCardViewDto();
  title: string = "Датали";
  constructor(private employeeService: EmployeeService, public activeModal: NgbActiveModal, private ngbCalendar: NgbCalendar, private dateAdapter: NgbDateAdapter<Date>) { }

  ngOnInit() {
    if (!this.state) this.state = State.Add;
    if (this.state == State.Edit) {
      this.loadData();
    }
  }

  loadData() {
    this.employeeService.getById(this.employeeId).subscribe(x => {
      if (!x) return;
      this.model = x;

    })
  }

  close() {
    this.activeModal.close();
  }

  save() {
    switch (this.state) {
      case (State.Edit): {
        this.employeeService.update(this.model).subscribe(x => {
          this.activeModal.close(true);
        });
        break;
      }

      case (State.Add): {
        this.employeeService.add(this.model).subscribe(x => {
          this.activeModal.close(true);
        });
        break;
      }
    }
  }
}
