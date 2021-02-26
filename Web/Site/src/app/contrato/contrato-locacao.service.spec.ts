import { TestBed } from '@angular/core/testing';

import { ContratoLocacaoService } from './contrato-locacao.service';

describe('ContratoLocacaoService', () => {
  let service: ContratoLocacaoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContratoLocacaoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
