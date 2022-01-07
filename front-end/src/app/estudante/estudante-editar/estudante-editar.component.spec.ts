import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstudanteEditarComponent } from './estudante-editar.component';

describe('EstudanteEditarComponent', () => {
  let component: EstudanteEditarComponent;
  let fixture: ComponentFixture<EstudanteEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstudanteEditarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstudanteEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
