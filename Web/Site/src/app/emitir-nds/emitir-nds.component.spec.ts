import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmitirNdsComponent } from './emitir-nds.component';

describe('EmitirNdsComponent', () => {
  let component: EmitirNdsComponent;
  let fixture: ComponentFixture<EmitirNdsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmitirNdsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmitirNdsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
