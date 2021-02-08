import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioMenuComponent } from './usuario-menu.component';

describe('UsuarioMenuComponent', () => {
  let component: UsuarioMenuComponent;
  let fixture: ComponentFixture<UsuarioMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsuarioMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
