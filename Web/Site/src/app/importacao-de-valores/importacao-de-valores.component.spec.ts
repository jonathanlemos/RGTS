import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportacaoDeValoresComponent } from './importacao-de-valores.component';

describe('ImportacaoDeValoresComponent', () => {
  let component: ImportacaoDeValoresComponent;
  let fixture: ComponentFixture<ImportacaoDeValoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportacaoDeValoresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportacaoDeValoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
