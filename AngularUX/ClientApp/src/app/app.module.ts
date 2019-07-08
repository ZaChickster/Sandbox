import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CsvUploaderComponent } from './csv-uploader/csv-uploader.component';
import { CsvTableComponent } from './csv-table/csv-table.component';
import { AppDataService } from './appdata.service';

@NgModule({
  declarations: [
    AppComponent,
    CsvUploaderComponent,
    CsvTableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [AppDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
