import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BandejaCursosComponent } from './bandeja-cursos.component';

describe('BandejaCursosComponent', () => {
  let component: BandejaCursosComponent;
  let fixture: ComponentFixture<BandejaCursosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BandejaCursosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BandejaCursosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
