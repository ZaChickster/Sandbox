import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsvUploaderComponent } from './csv-uploader.component';
import { AppDataService } from '../utils/appdata.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

describe('CsvUploaderComponent', () => {
  let component: CsvUploaderComponent;
  let fixture: ComponentFixture<CsvUploaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsvUploaderComponent ],
      imports: [ HttpClientModule, ReactiveFormsModule ],
      providers: [ AppDataService ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsvUploaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
