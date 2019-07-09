import { Component, OnInit } from '@angular/core';
import { FileData } from '../utils/filedata.model';
import { AppDataService } from '../utils/appdata.service';

@Component({
  selector: 'app-csv-table',
  templateUrl: './csv-table.component.html',
  styleUrls: ['./csv-table.component.scss']
})
export class CsvTableComponent implements OnInit {
  allData: FileData[] = [];

  constructor(private dataService: AppDataService) { }

  ngOnInit() {
    this.dataService.loadData().subscribe(data => {
      if (data) {
        this.allData = data;
      } else {
        this.allData = [];
      }
    });
  }

}
