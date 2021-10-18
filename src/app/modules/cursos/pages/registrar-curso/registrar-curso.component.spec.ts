import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrarCursoComponent } from './registrar-curso.component';

describe('RegistrarCursoComponent', () => {
  let component: RegistrarCursoComponent;
  let fixture: ComponentFixture<RegistrarCursoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistrarCursoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrarCursoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
