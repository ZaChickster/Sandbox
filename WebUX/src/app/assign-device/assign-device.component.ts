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
  error: string = '';

  constructor(private dataService: AppDataService) { }

  ngOnInit(): void {
  }

  assignDevice() {
    this.error = '';
    this.dataService.assignDevice(this.deviceId)
      .pipe(
        take(1),
        tap(res => {
          this.deviceId = '';
        }),
        catchError(error => {
          console.error(error);
          return of(error);
        })
      ).subscribe();
    
  }
}
