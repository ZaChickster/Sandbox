import { Injectable } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { FileData } from './filedata.model';
import { environment } from 'src/environments/environment';
import { DataCollection } from './datacollection.model';

@Injectable({
  providedIn: 'root'
})
export class AppDataService {

  constructor(private httpClient: HttpClient) { }

  public upload(data: any) {
    const uploadURL = `${environment.apiRoot}/api/csv/upload`;

    return this.httpClient.post<any>(uploadURL, data, {
      reportProgress: true,
      observe: 'events'
    }).pipe(map((event) => {
      switch (event.type) {
        case HttpEventType.UploadProgress:
          let progress: number = 0;
        
          if (event.total) {
            progress = Math.round(100 * event.loaded / event.total);
          }
        
          return { status: 'progress', message: progress };
        case HttpEventType.Response:
          return { status: 'finished', message: 100 };
        default:
          return { status: `unknown: ${event.type}`, message: 0 };
      }
    })
    );
  }

  public loadData(): Observable<FileData[]> {
    const dataUrl = `${environment.apiRoot}/api/csv/table`;

    return this.httpClient.get<any[]>(dataUrl).pipe(map(result => {
      const converted: FileData[] = [];

      result.forEach((dto, idx, col) => {
        converted.push(new FileData(dto));
      });

      return converted;
    }));
  }

  public assignDevice(deviceId: string): Observable<any> {
    const assignUrl = `${environment.apiRoot}/api/device/${deviceId}/assign`;

    return this.httpClient.get<any>(assignUrl, {});
  }

  public loadDeviceData(deviceId: number): Observable<DataCollection[]> {
    const dataUrl = `${environment.apiRoot}/api/device/${deviceId}/datacollection`;

    return this.httpClient.get<any[]>(dataUrl).pipe(map(result => {
      const converted: DataCollection[] = [];

      result.forEach((dto, idx, col) => {
        converted.push(new DataCollection(dto));
      });

      return converted;
    }));
  }
}
