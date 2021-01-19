import { Component, OnInit } from '@angular/core';
import { AppDataService } from '../utils/appdata.service';
import { DataCollection } from '../utils/datacollection.model';

@Component({
  selector: 'app-device-events',
  templateUrl: './device-events.component.html',
  styleUrls: ['./device-events.component.scss']
})
export class DeviceEventsComponent implements OnInit {
  deviceId : string = '';
  allData : DataCollection[] = []

  constructor(private dataService: AppDataService) { }

  ngOnInit(): void {

  }

  getEvents() {
    this.dataService.loadDeviceData(this.deviceId).subscribe(data => {
      if (data) {
        this.allData = data;
      } else {
        this.allData = [];
      }
      this.deviceId = '';
    });
  }
}
