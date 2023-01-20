import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PizzahandlerComponent } from './pizzahandler.component';

describe('PizzahandlerComponent', () => {
  let component: PizzahandlerComponent;
  let fixture: ComponentFixture<PizzahandlerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PizzahandlerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PizzahandlerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
