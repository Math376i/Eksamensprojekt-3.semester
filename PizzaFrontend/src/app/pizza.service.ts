import { Injectable } from '@angular/core';
import { Pizza } from './pizza';
import {PIZZAS} from './mock-pizzas';
import { Observable, of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  constructor() { }

  getPizzas(): Observable<Pizza[]> {
    const pizzas = of(PIZZAS);
    return pizzas;
  }
}
