import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { of } from 'rxjs';
import { catchError, take, tap } from 'rxjs/operators';
import { AppDataService } from '../utils/appdata.service';
import { DataCollection } from '../utils/datacollection.model';
import { environment } from 'src/environments/environment';
import * as signalR from '@microsoft/signalr';  

@Component({
  selector: 'app-device-events',
  templateUrl: './device-events.component.html',
  styleUrls: ['./device-events.component.scss']
})
export class DeviceEventsComponent implements OnInit, OnDestroy {
  desiredRows : number = 20;
  allData : DataCollection[] = []
  connection: signalR.HubConnection | undefined;

  constructor(private dataService: AppDataService, private changeDetectorRef: ChangeDetectorRef) { }
  
  ngOnInit(): void {
    this.connection = new signalR.HubConnectionBuilder()  
      .configureLogging(signalR.LogLevel.Information)  
      .withUrl(environment.apiRoot + '/trigger')  
      .build();

    this.connection.on("messageRecieved", (data) => {  
      this.getEvents();  
    });  

    this.connection.start().then(function () {  
        console.log('SignalR Connected!');  
      }).catch(function (err) {  
        return console.error(err.toString());  
      });
  }

  ngOnDestroy(): void {
    this.connection?.stop();
  }

  getEvents(deviceId?: number) {
    this.dataService.loadDeviceData(this.desiredRows)
      .pipe(
        take(1),
        tap(data => {
          if (data) {
            this.allData = data;
          } else {
            this.allData = [];
          }
          this.changeDetectorRef.detectChanges();
        }),
        catchError(error => {
          console.error(error);
          return of(error);
        })
      )
      .subscribe();
  }
}
