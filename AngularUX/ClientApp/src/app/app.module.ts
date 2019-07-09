import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CsvUploaderComponent } from './csv-uploader/csv-uploader.component';
import { CsvTableComponent } from './csv-table/csv-table.component';
import { AppDataService } from './utils/appdata.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CsvUploaderComponent,
    CsvTableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [AppDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
