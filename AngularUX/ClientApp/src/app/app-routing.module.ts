import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CsvUploaderComponent } from './csv-uploader/csv-uploader.component';
import { CsvTableComponent } from './csv-table/csv-table.component';


const routes: Routes = [
  {
    path: `uploader`,
    component: CsvUploaderComponent
  },
  {
    path: `table`,
    component: CsvTableComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
