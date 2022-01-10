import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstudanteDetalharComponent } from './estudante-detalhar.component';

describe('EstudanteDetalharComponent', () => {
  let component: EstudanteDetalharComponent;
  let fixture: ComponentFixture<EstudanteDetalharComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstudanteDetalharComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstudanteDetalharComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
