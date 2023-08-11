import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-delete-info',
  templateUrl: './delete-info.component.html',
  styleUrls: ['./delete-info.component.scss']
})
export class DeleteInfoComponent implements OnInit {

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  close() {
    this.activeModal.close(false);
  }

  ok() {
    this.activeModal.close(true);
  }

}
