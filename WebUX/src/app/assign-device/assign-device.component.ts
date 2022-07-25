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
  assignDeviceId?: number = undefined;
  messageDeviceId?: number = undefined;
  assignMessage: string = '';
  messageMessage: string = '';
  toSend: string = '';

  constructor(private dataService: AppDataService) { }

  ngOnInit(): void {
  }

  assignDevice() {
    const device = this.assignDeviceId || 0;

    if (device == 0)
      return;
    
    this.assignMessage = '';    
    this.dataService.assignDevice(device)
      .pipe(
        take(1),
        tap(res => {
          this.assignMessage = `Device ${this.assignDeviceId} has been registered.`;
          this.assignDeviceId = undefined;          
        }),
        catchError(error => {
          console.error(error);
          this.assignMessage = JSON.stringify(error);
          return of(error);
        })
      ).subscribe();    
  }

  sendMessage() {
    const device = this.messageDeviceId || 0;

    if (device == 0)
      return;

    this.messageMessage = '';
    this.dataService.messageDevice(device, this.toSend)
      .pipe(
        take(1),
        tap(res => {
          this.messageMessage = `Message sent to ${this.messageDeviceId}.`;
          this.messageDeviceId = undefined;          
        }),
        catchError(error => {
          console.error(error);
          this.messageMessage = JSON.stringify(error);
          return of(error);
        })
      ).subscribe();    
  }
}
