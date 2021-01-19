import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CsvUploaderComponent } from './csv-uploader/csv-uploader.component';
import { CsvTableComponent } from './csv-table/csv-table.component';
import { AppDataService } from './utils/appdata.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AssignDeviceComponent } from './assign-device/assign-device.component';
import { DeviceEventsComponent } from './device-events/device-events.component';

@NgModule({
  declarations: [
    AppComponent,
    CsvUploaderComponent,
    CsvTableComponent,
    AssignDeviceComponent,
    DeviceEventsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AppDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
