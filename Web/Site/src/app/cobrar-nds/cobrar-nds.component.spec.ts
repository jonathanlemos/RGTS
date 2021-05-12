import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CobrarNdsComponent } from './cobrar-nds.component';

describe('CobrarNdsComponent', () => {
  let component: CobrarNdsComponent;
  let fixture: ComponentFixture<CobrarNdsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CobrarNdsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CobrarNdsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
