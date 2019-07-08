import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AppDataService } from '../appdata.service';

@Component({
  selector: 'app-csv-uploader',
  templateUrl: './csv-uploader.component.html',
  styleUrls: ['./csv-uploader.component.scss']
})
export class CsvUploaderComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private uploadService: AppDataService) { }

  ngOnInit() {
  }

}
