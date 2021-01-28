/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PermissaoServiceService } from './permissao.service';

describe('Service: PermissaoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PermissaoServiceService]
    });
  });

  it('should ...', inject([PermissaoServiceService], (service: PermissaoServiceService) => {
    expect(service).toBeTruthy();
  }));
});
