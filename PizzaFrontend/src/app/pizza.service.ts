import { Injectable } from '@angular/core';
import { pizza } from './pizza';

import { Observable, of } from 'rxjs';
import {PIZZAS} from "./mock-pizzas";


@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  constructor() { }

  getPizzas(): Observable<pizza[]> {
    const pizzas = of(PIZZAS);
    return pizzas;
  }
}
