import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AppDataService } from '../utils/appdata.service';

@Component({
  selector: 'app-csv-uploader',
  templateUrl: './csv-uploader.component.html',
  styleUrls: ['./csv-uploader.component.scss']
})
export class CsvUploaderComponent implements OnInit {
  form: FormGroup;
  error: string = '';
  userId = 1;
  uploadResponse = { status: '', message: 0 };

  constructor(private formBuilder: FormBuilder, private uploadService: AppDataService) { 
    this.form = this.formBuilder.group({
      csvFile: ['']
    });
  }

  ngOnInit() {
    
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      const input = this.form.get('csvFile');

      if (input) {
        input.setValue(file);
      }      
    }
  }

  onSubmit() {
    const formData = new FormData();
    const input = this.form.get('csvFile');

    if (input) {      
      formData.append('file', input.value);
    }  

    this.uploadService.upload(formData).subscribe(
      (res) => this.uploadResponse = res,
      (err) => this.error = err
    );
  }
}
