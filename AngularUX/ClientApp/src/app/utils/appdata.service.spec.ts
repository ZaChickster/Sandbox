import { TestBed } from '@angular/core/testing';

import { AppDataService } from './appdata.service';
import { HttpClientModule } from '@angular/common/http';

describe('AppdataService', () => {
  beforeEach(() => TestBed.configureTestingModule({ imports: [ HttpClientModule ] }));

  it('should be created', () => {
    const service: AppDataService = TestBed.get(AppDataService);
    expect(service).toBeTruthy();
  });
});
