import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroPermissaoComponent } from './cadastro-permissao.component';

describe('CadastroPermissaoComponent', () => {
  let component: CadastroPermissaoComponent;
  let fixture: ComponentFixture<CadastroPermissaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroPermissaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroPermissaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
