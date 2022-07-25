import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CsvUploaderComponent } from './csv-uploader/csv-uploader.component';
import { CsvTableComponent } from './csv-table/csv-table.component';
import { AssignDeviceComponent } from './assign-device/assign-device.component';
import { DeviceEventsComponent } from './device-events/device-events.component';


const routes: Routes = [
  {
    path: `uploader`,
    component: CsvUploaderComponent
  },
  {
    path: `table`,
    component: CsvTableComponent
  },
  {
    path: `assign`,
    component: AssignDeviceComponent
  },
  {
    path: `devicedata`,
    component: DeviceEventsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
