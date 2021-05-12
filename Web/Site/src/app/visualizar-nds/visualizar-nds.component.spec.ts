import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarNdsComponent } from './visualizar-nds.component';

describe('VisualizarNdsComponent', () => {
  let component: VisualizarNdsComponent;
  let fixture: ComponentFixture<VisualizarNdsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarNdsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarNdsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
