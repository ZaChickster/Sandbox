import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsvTableComponent } from './csv-table.component';
import { AppDataService } from '../utils/appdata.service';
import { HttpClientModule } from '@angular/common/http';

describe('CsvTableComponent', () => {
  let component: CsvTableComponent;
  let fixture: ComponentFixture<CsvTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsvTableComponent ],
      imports: [ HttpClientModule ],
      providers: [ AppDataService ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsvTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
