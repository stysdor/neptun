import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { ShowingService } from './showing.service';

describe('ShowingService', () => {
  let service: ShowingService;

  beforeEach(() => {
    TestBed.configureTestingModule({providers:  [HttpClient]});
    service = TestBed.inject(ShowingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
