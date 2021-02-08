import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigurarPermissaoComponent } from './configurar-permissao.component';

describe('ConfigurarPermissaoComponent', () => {
  let component: ConfigurarPermissaoComponent;
  let fixture: ComponentFixture<ConfigurarPermissaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfigurarPermissaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigurarPermissaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
