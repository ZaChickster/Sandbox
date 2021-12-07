import {NgModule} from '@angular/core';

import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';

@NgModule({
    imports: [
      MatSidenavModule,
      MatToolbarModule,
      MatIconModule,
      MatListModule,
      MatTableModule,
      MatFormFieldModule,
      MatButtonModule,
      MatInputModule
    ],
    exports: [
      MatSidenavModule,
      MatToolbarModule,
      MatIconModule,
      MatListModule,
      MatTableModule,
      MatFormFieldModule,
      MatButtonModule,
      MatInputModule
    ]
  })
export class MaterialModule {}