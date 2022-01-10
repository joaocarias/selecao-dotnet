import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartaoCadastrarComponent } from './cartao-cadastrar.component';

describe('CartaoCadastrarComponent', () => {
  let component: CartaoCadastrarComponent;
  let fixture: ComponentFixture<CartaoCadastrarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartaoCadastrarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartaoCadastrarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
