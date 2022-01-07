import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstudanteCadastrarComponent } from './estudante-cadastrar.component';

describe('EstudanteCadastrarComponent', () => {
  let component: EstudanteCadastrarComponent;
  let fixture: ComponentFixture<EstudanteCadastrarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstudanteCadastrarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstudanteCadastrarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
