import { Component, OnInit } from '@angular/core';
import { FileData } from '../utils/filedata.model';
import { AppDataService } from '../utils/appdata.service';
import { catchError, switchMap, take, tap } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-csv-table',
  templateUrl: './csv-table.component.html',
  styleUrls: ['./csv-table.component.scss']
})
export class CsvTableComponent implements OnInit {
  allData: FileData[] = [];

  constructor(private dataService: AppDataService) { }

  ngOnInit() {
    this.dataService.loadData()
    .pipe(
      take(1),
      tap(data => {
        this.allData = data;
      }),
      catchError(error => {
        console.error(error);
        return of(error);
      })
    ).subscribe();
  }
}
