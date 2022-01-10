import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatriculaCadastrarComponent } from './matricula-cadastrar.component';

describe('MatriculaCadastrarComponent', () => {
  let component: MatriculaCadastrarComponent;
  let fixture: ComponentFixture<MatriculaCadastrarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MatriculaCadastrarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MatriculaCadastrarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
