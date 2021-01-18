import { Component, OnInit } from '@angular/core';
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
    this.dataService.assignDevice(this.deviceId).subscribe(
      (res) => {},
      (err) => this.error = err.message
    );
    this.deviceId = '';
  }
}
