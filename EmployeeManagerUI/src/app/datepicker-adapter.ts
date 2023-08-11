import { Injectable } from '@angular/core';
import { NgbDateAdapter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

/**
 * This Service handles how the date is represented in scripts i.e. ngModel.
 */
@Injectable()
export class CustomAdapter extends NgbDateAdapter<Date> {

    fromModel(value: Date | null): NgbDateStruct | null {
        if (value) {
            value = new Date(value);
            return {
                day: value.getDate(),
                month: value.getMonth()+1,
                year: value.getFullYear(),
            };
        }
        return null;
    }

    toModel(date: NgbDateStruct | null): Date | null {
        return date ? new Date(Date.UTC(date?.year, date?.month-1, date?.day)) : null;
    }
}