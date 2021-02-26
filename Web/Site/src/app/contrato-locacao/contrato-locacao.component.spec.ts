import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContratoLocacaoComponent } from './contrato-locacao.component';

describe('ContratoLocacaoComponent', () => {
  let component: ContratoLocacaoComponent;
  let fixture: ComponentFixture<ContratoLocacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContratoLocacaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContratoLocacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
