import { TestBed } from '@angular/core/testing';

import { ServiceRGTSService } from './service-rgts.service';

describe('ServiceRGTSService', () => {
  let service: ServiceRGTSService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceRGTSService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
