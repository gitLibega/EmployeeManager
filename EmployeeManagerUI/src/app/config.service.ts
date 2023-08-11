import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  baseUrl: string;
  constructor() {
    this.baseUrl = 'http://localhost:5266/api/';
  }
}
