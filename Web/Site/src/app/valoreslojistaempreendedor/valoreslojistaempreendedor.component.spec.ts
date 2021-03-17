import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValoreslojistaempreendedorComponent } from './valoreslojistaempreendedor.component';

describe('ValoreslojistaempreendedorComponent', () => {
  let component: ValoreslojistaempreendedorComponent;
  let fixture: ComponentFixture<ValoreslojistaempreendedorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValoreslojistaempreendedorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValoreslojistaempreendedorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
