import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportarValoresDeConsumoComponent } from './importar-valores-de-consumo.component';

describe('ImportarValoresDeConsumoComponent', () => {
  let component: ImportarValoresDeConsumoComponent;
  let fixture: ComponentFixture<ImportarValoresDeConsumoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportarValoresDeConsumoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportarValoresDeConsumoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
