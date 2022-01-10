import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PagamentoCadastrarComponent } from './pagamento-cadastrar.component';

describe('PagamentoCadastrarComponent', () => {
  let component: PagamentoCadastrarComponent;
  let fixture: ComponentFixture<PagamentoCadastrarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PagamentoCadastrarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PagamentoCadastrarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
