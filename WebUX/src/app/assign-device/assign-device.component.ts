import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';
import { catchError, take, tap } from 'rxjs/operators';
import { AppDataService } from '../utils/appdata.service';

@Component({
  selector: 'app-assign-device',
  templateUrl: './assign-device.component.html',
  styleUrls: ['./assign-device.component.scss']
})
export class AssignDeviceComponent implements OnInit {
  deviceId: string = '';
  message: string = ''

  constructor(private dataService: AppDataService) { }

  ngOnInit(): void {
  }

  assignDevice() {
    this.message = '';
    this.dataService.assignDevice(this.deviceId)
      .pipe(
        take(1),
        tap(res => {
          this.message = `Device ${this.deviceId} has been registered.`;
          this.deviceId = '';          
        }),
        catchError(error => {
          console.error(error);
          this.message = JSON.stringify(error);
          return of(error);
        })
      ).subscribe();
    
  }
}
